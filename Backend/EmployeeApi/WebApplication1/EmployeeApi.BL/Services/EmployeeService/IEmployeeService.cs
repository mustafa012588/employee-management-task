using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApi.DAL;

namespace EmployeeApi.BL
{
    public interface IEmployeeService
    {
        Task<List<EmployeeReadDto>> GetAllEmployeesAsync();
        Task<EmployeeReadDto?> GetEmployeeByIdAsync(int id);
        Task<EmployeeReadDto> AddEmployeeAsync(EmployeeCreateDto employeeDto);
        Task<bool> UpdateEmployeeAsync(int id, EmployeeUpdateDto employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
