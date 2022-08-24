using API.Data;
using API.Data.Models;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HostelsController : ControllerBase
    {
        private readonly DataContext _context;

        public HostelsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = _context.Hostels;
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var result = _context.Hostels.FirstOrDefault(p => p.Id == id);
            return Ok(result);
        }

        #region Create New Hostel

        [HttpPost]
        public ActionResult Create([FromBody] HostelCreate model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var hostel = new Hostel
            {
                Name = model.Name
            };

            _context.Hostels.Add(hostel);
            if (_context.SaveChanges() > 0)
            {
                return Ok("Record Inserted Successfully.");
            }
            return BadRequest(ModelState);

        }
        #endregion

        #region Update Existing Hostel
        [HttpPut()]
        public ActionResult Update([FromBody] HostelUpdate model)
        {
            var hostel= _context.Hostels.FirstOrDefault(p => p.Id == model.Id);
            if (hostel  == null) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            hostel.Name = model.Name;

            _context.Hostels.Update(hostel);
            if (_context.SaveChanges() > 0)
            {
                return Ok(hostel);
            }
            return BadRequest();

        }
        #endregion

        #region Delete Existing Hostel
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hostel = _context.Hostels.FirstOrDefault(p => p.Id == id);
            if (hostel == null) return NotFound();


            _context.Hostels.Remove(hostel);
            if (_context.SaveChanges() > 0)
            {
                return Ok("Record Deleted Successfully!");
            }
            return BadRequest();

        }
        #endregion
    }
}
