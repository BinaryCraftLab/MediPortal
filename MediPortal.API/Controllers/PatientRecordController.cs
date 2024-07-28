using MediPortal.API.Data;
using MediPortal.API.Models;
using MediPortal.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MediPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientRecordController : ControllerBase
    {
        private readonly MedicalPortalContext _context;

        public PatientRecordController(MedicalPortalContext context)
        {
            _context = context;
        }

        // GET: api/PatientRecord
        [HttpGet]
        public async Task<IActionResult> GetAllPatientRecords()
        {
            var records = await _context.PatientRecords.Include(x => x.Patient).ToListAsync();
            return Ok(records);
        }

        // GET: api/PatientRecord/getPatientRecordsByPatientNumber/{patientNumber}
        [HttpGet("getPatientRecordsByPatientNumber/{patientNumber}")]
        public async Task<IActionResult> GetPatientRecordsByPatientNumber(string patientNumber)
        {
            if (string.IsNullOrEmpty(patientNumber))
            {
                return BadRequest("Patient number cannot be null or empty.");
            }

            var patientRecords = await _context.PatientRecords
                .Where(x => x.Patient.PatientNumber == patientNumber)
                .Include(x => x.Patient)
                .ToListAsync();

            if (patientRecords == null || !patientRecords.Any())
            {
                return NotFound("No records found for the specified patient number.");
            }

            return Ok(patientRecords);
        }

        // POST: api/PatientRecord
        [HttpPost]
        public async Task<IActionResult> AddNewPatientRecord([FromBody] AddNewPatientRequest model)
        {
            if (model == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var newRecord = new PatientRecord
            {
                RecordContext = model.RecordContext,
                PatientId = model.PatientId,
                DoctorName = model.DoctorName,
                DateCreate = DateTime.UtcNow,
                DateUpdate = DateTime.UtcNow,
            };

            _context.PatientRecords.Add(newRecord);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPatientRecordsByPatientNumber), new { patientNumber = model.PatientId }, newRecord);
        }

        // GET: api/PatientRecord/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientRecord(int id)
        {
            var record = await _context.PatientRecords
                .Include(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (record == null)
            {
                return NotFound("Record not found.");
            }

            return Ok(record);
        }

        // DELETE: api/PatientRecord/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientRecord(int id)
        {
            var record = await _context.PatientRecords.FindAsync(id);

            if (record == null)
            {
                return NotFound("Record not found.");
            }

            _context.PatientRecords.Remove(record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/PatientRecord/updatePatientRecord/{id}
        [HttpPut("updatePatientRecord/{id}")]
        public async Task<IActionResult> UpdatePatientRecordDetails([FromBody] UpdateRecordDetailsRequest model, int id)
        {
            if (model == null || model.Id != id || !ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            var record = await _context.PatientRecords.FindAsync(id);

            if (record == null)
            {
                return NotFound("Record not found.");
            }

            record.RecordContext = model.RecordContext;
            record.DateUpdate = DateTime.UtcNow;

            _context.PatientRecords.Update(record);
            await _context.SaveChangesAsync();

            return Ok("Record updated successfully.");
        }
    }
}
