import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { EmployeeService } from '../services/employee.service';
import { EmployeeUpdateDto } from '../models/employee-update.dto';
import { EmployeeCreateDto } from '../models/employee-create.dto';
import { CommonModule } from '@angular/common';


@Component({
  standalone: true,
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  imports: [CommonModule, ReactiveFormsModule, RouterModule, FormsModule]
})

export class EmployeeFormComponent implements OnInit {
  employeeForm: FormGroup;
  isEditMode = false;
  employeeId!: number;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private employeeService: EmployeeService
  ) {
    this.employeeForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      position: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      const id = params.get('id');
      if (id) {
        this.isEditMode = true;
        this.employeeId = +id;
        this.employeeService.getEmployeeById(this.employeeId).subscribe(employee => {
          this.employeeForm.patchValue(employee);
        });
      }
    });
  }

  onSubmit(): void {
    const formData = this.employeeForm.value;

    if (this.isEditMode) {
      const updatedEmployee: EmployeeUpdateDto = formData;
      this.employeeService.updateEmployee(this.employeeId, updatedEmployee).subscribe(() => {
        this.router.navigate(['/']);
      });
    } else {
      const newEmployee: EmployeeCreateDto = formData;
      this.employeeService.addEmployee(newEmployee).subscribe(() => {
        this.router.navigate(['/']);
      });
    }
  }
  goBack() {
    this.router.navigate(['/']);
  }
  
}
