using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApi.DAL;

namespace EmployeeApi.BL
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepository;

        public EmployeeService(IEmployeeRepo employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<EmployeeReadDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeReadDto
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Position = e.Position
            }).ToList();
        }

        public async Task<EmployeeReadDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                return null;
            }

            return new EmployeeReadDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position
            };
        }

        public async Task<EmployeeReadDto> AddEmployeeAsync(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Email = employeeDto.Email,
                Position = employeeDto.Position
            };

            _employeeRepository.Add(employee);
            await _employeeRepository.SaveAsync();

            return new EmployeeReadDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Position = employee.Position
            };
        }


        public async Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeDto)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                return false;
          
                employee.FirstName = employeeDto.FirstName ?? employee.FirstName;
                employee.LastName = employeeDto.LastName ?? employee.LastName;
                employee.Email = employeeDto.Email ?? employee.Email;
                employee.Position = employeeDto.Position ?? employee.Position;

                _employeeRepository.Update(employee);
                await _employeeRepository.SaveAsync();
            return true;

        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                _employeeRepository.Delete(employee);
                await _employeeRepository.SaveAsync();
            }
        }
    }
}
