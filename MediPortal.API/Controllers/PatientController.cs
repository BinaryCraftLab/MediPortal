using MediPortal.API.Data;
using MediPortal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MediPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Patient, Doctor")]  // Ensure only users with the "Patient" role can access these endpoints
    public class PatientController : ControllerBase
    {
        private readonly MedicalPortalContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientController(MedicalPortalContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: api/Patient
        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Patient"))
            {
                return Forbid(); // Current user is not authorized
            }

            var patientList = await _context.Patients.ToListAsync();
            return Ok(patientList);
        }

        // GET: api/Patient/{patientNumber}
        [HttpGet("{patientNumber}")]
        public async Task<IActionResult> GetPatientByPatientNumber(string patientNumber)
        {
            if (string.IsNullOrEmpty(patientNumber))
            {
                return BadRequest("Patient number cannot be null or empty.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Patient"))
            {
                return Forbid(); // Current user is not authorized
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(x => x.PatientNumber == patientNumber);

            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            return Ok(patient);
        }

        // GET: api/Patient/patientById/{id}
        [HttpGet("patientById/{id}")]
        public async Task<IActionResult> GetPatientById(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid patient ID.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Patient"))
            {
                return Forbid(); // Current user is not authorized
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(x => x.Id == id);

            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            return Ok(patient);
        }

        // DELETE: api/Patient/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Invalid patient ID.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Patient"))
            {
                return Forbid(); // Current user is not authorized
            }

            var patient = await _context.Patients
                .FirstOrDefaultAsync(x => x.Id == id);

            if (patient == null)
            {
                return NotFound("Patient not found.");
            }

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Patient
        [HttpPost]
        public async Task<IActionResult> AddNewPatient([FromBody] Patient model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid patient data.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Patient"))
            {
                return Forbid(); // Current user is not authorized
            }

            _context.Patients.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientById), new { id = model.Id }, model);
        }

        // PUT: api/Patient/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatientDetails(string id, [FromBody] Patient model)
        {
            if (string.IsNullOrEmpty(id) || model == null || id != model.Id || !ModelState.IsValid)
            {
                return BadRequest("Invalid patient data.");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null || !await _userManager.IsInRoleAsync(currentUser, "Patient"))
            {
                return Forbid(); // Current user is not authorized
            }

            var existingPatient = await _context.Patients.FindAsync(id);

            if (existingPatient == null)
            {
                return NotFound("Patient not found.");
            }

            existingPatient.PatientNumber = model.PatientNumber;
            existingPatient.FirstName = model.FirstName;
            existingPatient.Address = model.Address;
            existingPatient.LastName = model.LastName;
            existingPatient.DateOfBirth = model.DateOfBirth;
            existingPatient.Country = model.Country;
            existingPatient.City = model.City;
            existingPatient.Age = model.Age;
            existingPatient.PhoneNumber = model.PhoneNumber;
            existingPatient.NextOfKinPhone = model.NextOfKinPhone;
            existingPatient.NextOfKinName = model.NextOfKinName;

            _context.Patients.Update(existingPatient);
            await _context.SaveChangesAsync();

            return Ok("Patient record successfully updated.");
        }
    }
}
