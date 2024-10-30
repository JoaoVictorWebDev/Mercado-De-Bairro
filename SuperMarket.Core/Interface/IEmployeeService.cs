using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Interface
{
    public interface IEmployeeService
    {
        Task<ServiceResult<EmployeeDTO>>AddEmployeeAsync(EmployeeDTO employee);
        Task<ServiceResult<EmployeeDTO>> GetAllEmployeesAsync();
        Task<ServiceResult<Employee>> GetEmployeesByIdAsync(long id);
        Task<ServiceResult<EmployeeDTO>> updateEmployeeByIDAsync(long id, EmployeeDTO employeeDTO);
        Task<ServiceResult<EmployeeDTO>> DeleteByIDAsync(long id);
        Task<ServiceResult<EmployeeDTO>> DeleteAllEmployees();

    }
}
