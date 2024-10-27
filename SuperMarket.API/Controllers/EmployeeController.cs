﻿using AutoMapper;
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
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IMapper mapper, IEmployeeService employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet("/getEmployeeById{id}")]
        public async Task<IActionResult> GetEmployeeById(long id)
        {
            var getEmployeeById = _employeeService.GetEmployeesByIdAsync(id);
            return Ok(new { Message = $"Employee Found With {id} !", Data = getEmployeeById });
        }

        [HttpPost("/addEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null)
            {
                return BadRequest(new { Message = "Invalid Data " });
            }

            var addedEmployeeDTO = await _employeeService.AddEmployeeAsync(employeeDTO);
            return Ok(new { Message = "Employee Created!", Data = addedEmployeeDTO });
        }

        [HttpGet("/allEmployees")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var GetAllEmployees = await _employeeService.GetAllEmployeesAsync();
            return Ok(new { Message = "Employees Found", Data = GetAllEmployees });
        }

        [HttpPut("/updateEmployeeById{id}")]
        public async Task<IActionResult> updateEmployeeByID(long id, EmployeeDTO employeeDTO)
        {
            var UpdateEmployee = await _employeeService.updateEmployeeByIDAsync(id, employeeDTO);
            return Ok(new { Message = "Employe Updated!", Data = UpdateEmployee });
        }

        [HttpDelete("/deleteEmployeeByID{id}")]
        public async Task<IActionResult> deleteEmployeeByID(long id)
        {
            var deleteEmployee = await _employeeService.DeleteByIDAsync(id);
            return Ok(new { Message = "Employee Deleted !", Data = deleteEmployee });
        }
    }
}

