using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FLM_WEB_API.Models;

namespace FLM_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursemastersController : ControllerBase
    {
        private readonly LmsContext _context;

        public CoursemastersController(LmsContext context)
        {
            _context = context;
        }

        // GET: api/Coursemasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coursemaster>>> GetCoursemasters()
        {
            return await _context.Coursemasters.ToListAsync();
        }

        // GET: api/Coursemasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Coursemaster>> GetCoursemaster(int id)
        {
            var coursemaster = await _context.Coursemasters.FindAsync(id);

            if (coursemaster == null)
            {
                return NotFound();
            }

            return coursemaster;
        }

        // PUT: api/Coursemasters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoursemaster(int id, Coursemaster coursemaster)
        {
            if (id != coursemaster.Id)
            {
                return BadRequest();
            }

            _context.Entry(coursemaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoursemasterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Coursemasters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Coursemaster>> PostCoursemaster(Coursemaster coursemaster)
        {
            _context.Coursemasters.Add(coursemaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoursemaster", new { id = coursemaster.Id }, coursemaster);
        }

        // DELETE: api/Coursemasters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoursemaster(int id)
        {
            var coursemaster = await _context.Coursemasters.FindAsync(id);
            if (coursemaster == null)
            {
                return NotFound();
            }

            _context.Coursemasters.Remove(coursemaster);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("CallAI")]
        public string CallAI(string prompt) {
            return "";
        }
        private bool CoursemasterExists(int id)
        {
            return _context.Coursemasters.Any(e => e.Id == id);
        }
    }
}
