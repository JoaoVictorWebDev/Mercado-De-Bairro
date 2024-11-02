using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Moq;
using SuperMarket.Core.Domain.DTO;
using SuperMarket.Core.Entities;
using SuperMarket.Core.Interface.Repositories;
using SuperMarket.Core.Service;
using SuperMarket.Core.Structs;
using SuperMarket.Data.Contexts;

namespace SuperMarket.Test
{
    public class EmployeeServiceTests
    {
        private readonly Mock<ApplicationDBContext> _dbContextMock;
        private readonly Mock<IEmployeeRepository> _employeeRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EmployeeService _employeeService;
        public EmployeeServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDBContext>()
                .UseInMemoryDatabase(databaseName: "EmployeeServiceTests")
                .Options;
            _dbContextMock = new Mock<ApplicationDBContext>(options);
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _mapperMock = new Mock<IMapper>();
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object, _mapperMock.Object);
        }

    }
}