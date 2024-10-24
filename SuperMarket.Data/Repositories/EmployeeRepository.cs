using SuperMarket.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarket.Data.Contexts;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Interface;
using AutoMapper;
using SuperMarket.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace SuperMarket.Data.Repositories
{
    public class EmployeeRepository: IEmployeeRepository { 
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public EmployeeRepository(ApplicationDBContext context, IMapper mapper)
        {
                _context = context;
                _mapper = mapper;
        }
        
        public async Task AddEmployeeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var employeeAsync = await _context.Employees.ToListAsync();
            return _mapper.Map<List<EmployeeDTO>>(employeeAsync);
        }
    }
}
