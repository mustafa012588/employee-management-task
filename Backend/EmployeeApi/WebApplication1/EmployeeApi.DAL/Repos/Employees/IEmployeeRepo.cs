using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.DAL
{
    public interface IEmployeeRepo 
    {
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Task SaveAsync();
    }
}
