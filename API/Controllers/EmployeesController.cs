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

        #region Get All Employees
        [HttpGet]
        public ActionResult Get()
        {
            var result = _context.Employees;
            return Ok(result);
        }

        #endregion

        #region Get Employee By Id

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null) return NotFound();
            
            return Ok(employee);
        }
        #endregion

        #region Create New Employee

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
            if (_context.SaveChanges()>0)
            {
                return Ok("Record Inserted Successfully.");
            }
            return BadRequest(ModelState);
            
        }
        #endregion

        #region Update Existing Employee
        [HttpPut()]
        public ActionResult Update([FromBody] EmployeeUpdate model)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.Id == model.Id);
            if (employee == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            employee.Name = model.Name;
            employee.Code = model.Code;

            _context.Employees.Update(employee);
            if (_context.SaveChanges()>0)
            {
                return Ok(employee);
            }
            return BadRequest();

        }
        #endregion

        #region Delete Existing Employee
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = _context.Employees.FirstOrDefault(p => p.Id == id);
            if (employee == null) return NotFound();


            _context.Employees.Remove(employee);
            if (_context.SaveChanges() > 0)
            {
                return Ok("Record Deleted Successfully!");
            }
            return BadRequest();

        }
        #endregion
    }
}
