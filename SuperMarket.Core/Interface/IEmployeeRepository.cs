using SuperMarket.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Core.Domain.DTO;

namespace SuperMarket.Core.Interface
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task <List<EmployeeDTO>> GetAllEmployeesAsync();
    }
}
