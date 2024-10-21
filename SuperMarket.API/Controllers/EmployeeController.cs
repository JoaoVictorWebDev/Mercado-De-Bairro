using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Data.Contexts;

namespace SuperMarket.API.Controllers
{
    [ApiController]
    [Route("api/employee")]
    public class EmployeeController:ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public EmployeeController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> AddEmployee()
        {

        }
    }
}
