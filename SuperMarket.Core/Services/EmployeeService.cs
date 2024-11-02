using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface.Repositories;
using SuperMarket.Core.Interface.Service;
using SuperMarket.Core.Structs;
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

        public async Task<ServiceResult<EmployeeDTO>> AddEmployeeAsync(EmployeeDTO employeeDTO)
        {
            if(employeeDTO == null)
            {
                return ServiceResult<EmployeeDTO>.Error("Product Not Found");
            }
            var addEmployeeDTO = _mapper.Map<Employee>(employeeDTO);
            await _employeeRepository.AddEmployeeAsync(addEmployeeDTO);
            return employeeDTO;
        }

        public async Task<ServiceResult<EmployeeDTO>> GetAllEmployeesAsync()
        {
            var getAllEmployees = await _employeeRepository.GetAllEmployeesAsync();
            if(getAllEmployees == null)
            {
                return ServiceResult<EmployeeDTO>.Error("Employee Not Found!");
            }
            return _mapper.Map<EmployeeDTO>(getAllEmployees);
        }

        public async Task<ServiceResult<Employee>> GetEmployeesByIdAsync(long id)
        {
           var getEmployeeByID = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(getEmployeeByID == null)
            {
                return ServiceResult<Employee>.Error($"Employee With ID :{id} Not Found!");
            }
            return _mapper.Map<Employee>(getEmployeeByID); 
        }

        public async Task <ServiceResult<EmployeeDTO>> updateEmployeeByIDAsync(long id, EmployeeDTO employeeDTO)
        {
            var existingEmployee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(existingEmployee == null)
            {
                return ServiceResult<EmployeeDTO>.Error("Product Not Found");
            }
            var updateAsync = await _employeeRepository.updateEmployeeByIDAsync(id, employeeDTO);
            var updatedEmployeeDTO = _mapper.Map<EmployeeDTO>(updateAsync);
            return updatedEmployeeDTO;
        }

        public async Task<ServiceResult<EmployeeDTO>> DeleteByIDAsync(long id)
        {
            var GetIdFromEmployee = await _employeeRepository.GetEmployeesByIdAsync(id);
            if(GetIdFromEmployee == null)
            {
                return ServiceResult<EmployeeDTO>.Error("Product Not Found");

            }
            var DeleteByID = await _employeeRepository.DeleteByIDAsync(id);
            return DeleteByID;
        }

        public async Task<ServiceResult<EmployeeDTO>> DeleteAllEmployees()
        {
            try { 
                var GetAllEmployees = await _employeeRepository.DeleteAllEmployees();

                if (GetAllEmployees == null)
                {
                    ServiceResult<EmployeeDTO>.Error("Product Not Found!");
                }
                var deleted =  _mapper.Map<EmployeeDTO>(GetAllEmployees);
                return ServiceResult<EmployeeDTO>.Success(deleted);
            }
            catch (Exception ex)
            {
                return ServiceResult<EmployeeDTO>.Exception(ex);
            }
        }
    }
}
