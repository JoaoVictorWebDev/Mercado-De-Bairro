using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface;
using SuperMarket.Data.Contexts;

namespace SuperMarket.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
        }

        [HttpPost("/addEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest(new { Message = "Invalid Data " });
            }

            var employeeInstance = _mapper.Map<Employee>(employeeDTO);
            await _employeeRepository.AddEmployeeAsync(employeeInstance);
            return Created("/api/controller" + employeeInstance.Id, new { Message = "Employee Created!", Data = employeeInstance });
        }

        [HttpGet("/allEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var GetAllEmployees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(new { Message = "Employees Found", Data = GetAllEmployees });
        }
    }
}

