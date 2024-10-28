using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Exceptions;
using SuperMarket.Core.Interfaces;
using SuperMarket.Data.Contexts;

namespace SuperMarket.Data.Repositories
{
    public class ProductRepository:IProductRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public ProductRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductsDTO> AddProductsAsync(Products products)
        {
            if (products == null)
            {
            }

            var productsEntry = await _context.Products.AddAsync(products);
            await _context.SaveChangesAsync();
            var productsDTO = _mapper.Map<ProductsDTO>(products);
            return productsDTO;
        }

        //public async Task<List<EmployeeDTO>> GetAllEmployeesAsync()
        //{
        //    var employeeAsync = await _context.Employees.ToListAsync();
        //    return _mapper.Map<List<EmployeeDTO>>(employeeAsync);
        //}

        //public async Task<EmployeeDTO> updateEmployeeByIDAsync(long id, EmployeeDTO employeeDTO)
        //{
        //    var employeeToUpdate = await _context.Employees
        //        .FirstOrDefaultAsync(e => e.Id == id);
        //    employeeToUpdate.Name = employeeDTO.Name;
        //    employeeToUpdate.PostalCode = employeeDTO.PostalCode;
        //    employeeToUpdate.PublicPlace = employeeDTO.PublicPlace;
        //    employeeToUpdate.region = employeeDTO.Region;
        //    employeeToUpdate.Role = employeeDTO.Role;
        //    employeeToUpdate.Salary = employeeDTO.Salary;
        //    employeeToUpdate.state = employeeDTO.State;
        //    employeeToUpdate.uf = employeeDTO.Uf;
        //    employeeToUpdate.CPF = employeeDTO.CPF;
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<EmployeeDTO>(employeeToUpdate);
        //}

        //public async Task<Employee> GetEmployeesByIdAsync(long id)
        //{
        //    var getEmploeeysID = await _context.Employees.FindAsync(id);
        //    return getEmploeeysID;
        //}

        //public async Task<EmployeeDTO> DeleteByIDAsync(long id)
        //{
        //    var employeeToDelete = await _context.Employees
        //        .FirstOrDefaultAsync(e => e.Id == id);
        //    if (employeeToDelete == null)
        //    {
        //        throw new ResourceNotFoundException($"Employee with ID {id} can't be located.");
        //    }
        //    _context.Employees.Remove(employeeToDelete);
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<EmployeeDTO>(employeeToDelete);
        //}

        //public async Task<List<EmployeeDTO>> DeleteAllEmployees()
        //{
        //    var allEmployees = await _context.Employees.ToListAsync();
        //    _context.Employees.RemoveRange(allEmployees);
        //    await _context.SaveChangesAsync();
        //    return _mapper.Map<List<EmployeeDTO>>(allEmployees);
        //}
    }
}
