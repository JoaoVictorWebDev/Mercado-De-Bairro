using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Interface
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO>AddEmployeeAsync(EmployeeDTO employee);
        Task<List<EmployeeDTO>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeesByIdAsync(long id);
        Task<EmployeeDTO> updateEmployeeByIDAsync(long id, EmployeeDTO employeeDTO);
        Task<EmployeeDTO> DeleteByIDAsync(long id);

    }
}
