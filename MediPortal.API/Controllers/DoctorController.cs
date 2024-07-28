using MediPortal.API.Data;
using MediPortal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MediPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly MedicalPortalContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DoctorController(MedicalPortalContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            // Get all users with the "Doctor" role
            var doctorRole = "Doctor";

            var doctorUsers = await _userManager.Users
                .Where(u => _userManager.IsInRoleAsync(u, doctorRole).Result)
                .ToListAsync();

            var doctorIds = doctorUsers.Select(d => d.Id).ToList();

            var doctors = await _context.Doctors
                .Where(d => doctorIds.Contains(d.Id))
                .ToListAsync();

            return Ok(doctors);
        }

        // GET: api/Doctor/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorById(string id)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return Ok(doctor);
        }

        // POST: api/Doctor
        [HttpPost]
        public async Task<IActionResult> AddNewDoctor([FromBody] Doctor model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (await _userManager.IsInRoleAsync(currentUser, "Doctor"))
                {
                    _context.Doctors.Add(model);
                    await _context.SaveChangesAsync();
                    return CreatedAtAction(nameof(GetDoctorById), new { id = model.Id }, model);
                }
                return Forbid(); // User is not authorized to add a doctor
            }
            return BadRequest(ModelState);
        }

        // PUT: api/Doctor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(string id, [FromBody] Doctor model)
        {
            if (id != model.Id || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (await _userManager.IsInRoleAsync(currentUser, "Doctor"))
            {
                var existingDoctor = await _context.Doctors.FindAsync(id);
                if (existingDoctor == null)
                {
                    return NotFound();
                }

                existingDoctor.FirstName = model.FirstName;
                existingDoctor.Specialization = model.Specialization;
                existingDoctor.LastName = model.LastName;
                existingDoctor.Email = model.Email;
                existingDoctor.Bio = model.Bio;

                _context.Doctors.Update(existingDoctor);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            return Forbid(); // User is not authorized to update a doctor
        }

        // DELETE: api/Doctor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (await _userManager.IsInRoleAsync(currentUser, "Doctor"))
            {
                var doctor = await _context.Doctors.FindAsync(id);
                if (doctor == null)
                {
                    return NotFound();
                }

                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            return Forbid(); // User is not authorized to delete a doctor
        }
    }
}
