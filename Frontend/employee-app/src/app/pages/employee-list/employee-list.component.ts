import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; 
import { RouterModule, Router } from '@angular/router';
import { EmployeeService } from '../../services/employee.service';
import { Employee } from '../../models/employee.model.ts';

@Component({
  selector: 'app-employee-list',
  standalone: true,
  imports: [CommonModule, RouterModule, FormsModule], 
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  private employeeService = inject(EmployeeService);
  private router = inject(Router);

  allEmployees: Employee[] = [];
  employees: Employee[] = [];
  isLoading = true;
  error = '';
  searchText = ''; 

  // Pagination properties
  currentPage = 1;
  pageSize = 5;
  totalPages = 1;

  ngOnInit(): void {
    console.log('Current route:', this.router.url);

    this.fetchEmployees();
  }

  fetchEmployees() {
    this.employeeService.getAllEmployees().subscribe({
      next: data => {
        this.allEmployees = data;
        this.totalPages = Math.ceil(this.allEmployees.length / this.pageSize);
        this.applyFilter();
        this.isLoading = false;
      },
      error: err => {
        this.error = 'Failed to load employees';
        this.isLoading = false;
      }
    });
  }

  applyFilter() {
    const text = this.searchText.toLowerCase();
    const filtered = this.allEmployees.filter(emp =>
      emp.firstName.toLowerCase().includes(text) ||
      emp.lastName.toLowerCase().includes(text) ||
      emp.email.toLowerCase().includes(text) ||
      emp.position.toLowerCase().includes(text)
    );

    this.totalPages = Math.ceil(filtered.length / this.pageSize);
    const startIndex = (this.currentPage - 1) * this.pageSize;
    this.employees = filtered.slice(startIndex, startIndex + this.pageSize);
  }

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.currentPage = page;
      this.applyFilter();
    }
  }

  editEmployee(id: number) {
    this.router.navigate(['/edit', id]);
  }

  deleteEmployee(id: number) {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.employeeService.deleteEmployee(id).subscribe({
        next: () => this.fetchEmployees(),
        error: () => alert('Failed to delete employee')
      });
    }
  }

  addEmployee() {
    this.router.navigate(['/create']);
  }
  onSearch() {
    this.currentPage = 1;
    this.applyFilter();
  }
  
}
