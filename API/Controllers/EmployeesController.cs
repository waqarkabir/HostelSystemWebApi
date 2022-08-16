using API.Data;
using API.Data.Entities;
using API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _context.Employees;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _context.Employees.FirstOrDefault(p => p.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EmployeeCreate model)
        { 
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var employee = new Employee
            {
                Name = model.Name,
                Code = model.Code
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok();
        }
    }
}
