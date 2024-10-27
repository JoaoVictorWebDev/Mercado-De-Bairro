using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Exceptions;
using SuperMarket.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Core.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeDTO> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            if(employeeDTO == null)
            {
                    throw new ResourceNotFoundException("Employee Cant be Null!");
            }
            var addEmployeeDTO = _mapper.Map<Employee>(employeeDTO);
            await _employeeRepository.AddEmployeeAsync(addEmployeeDTO);
            return employeeDTO;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var getAllEmployees = await _employeeRepository.GetAllEmployeesAsync();
            if(getAllEmployees == null)
            {
                throw new ResourceNotFoundException("Employees not found");
            }
            return getAllEmployees;
        }

        public async Task <Employee> GetEmployeesByIdAsync(long id)
        {
           var getEmployeeByID = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(getEmployeeByID == null)
            {
                throw new ResourceNotFoundException($"Employee with ID {id} Can't be Located!" );
            }
            return getEmployeeByID; 
        }

        public async Task <EmployeeDTO> updateEmployeeByIDAsync(long id, EmployeeDTO employeeDTO)
        {
            var existingEmployee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(existingEmployee == null)
            {
                throw new ResourceNotFoundException($"Employee With ID {id} Can't be Located");
            }
            var updateAsync = await _employeeRepository.updateEmployeeByIDAsync(id, employeeDTO);
            var updatedEmployeeDTO = _mapper.Map<EmployeeDTO>(updateAsync);
            return updatedEmployeeDTO;
        }

        public async Task <EmployeeDTO> DeleteByIDAsync(long id)
        {
            var GetIdFromEmployee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(GetIdFromEmployee == null)
            {
                throw new ResourceNotFoundException($"Employee With ID {id} Can't be locate");
            }

            var DeleteByID = await _employeeRepository.DeleteByIDAsync(id);
            return DeleteByID;
        }
    }
}
