using MediPortal.API.Data;
using MediPortal.API.Models;
using MediPortal.API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public IActionResult GetAllPatientRecords()
        {
            var records = _context.PatientRecords.ToList();
            return Ok(records);
        }
        [HttpGet("getPatientRecordsByPatientNumber/{PatientNumber}")]
        public IActionResult GetPatientRecordsByPatientNumber(string? patientNumber)
        {
            if (!string.IsNullOrEmpty(patientNumber)) { 
                var patientRecords  = _context.PatientRecords.Include(x=>x.Patient)
                    .Select(x=>x.Patient.PatientNumber  == patientNumber).ToList();
                if (patientRecords != null) {
                    return Ok(patientRecords);
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public IActionResult AddNewPatientRecord([FromBody] AddNewPatientRequest model)
        {
            if (ModelState.IsValid)
            {
                var obj = new PatientRecord
                {
                    RecordContext = model.RecordContext,
                    PatientId = model.PatientId,
                    DoctorName = model.DoctorName,
                    DateCreate = DateTime.UtcNow,
                    DateUpdate = DateTime.UtcNow,
                };
                _context.PatientRecords.Add(obj);
                _context.SaveChanges();
                return Ok("The patient record successful added");
            }
            return BadRequest();
        }
        [HttpGet("{Id}")]
        public IActionResult DeletePatientRecord(int? Id)
        {
            if (Id != null || Id != 0) { 
                var record  = _context.PatientRecords.FirstOrDefault(x=>x.Id == Id);
                if (record != null) {
                    return Ok(record);
                }
            }
            return BadRequest();
        }
        [HttpPut("/updatePatientRecord/{Id}")]
        public IActionResult UpdatePatientRecordDetails([FromBody] UpdateRecordDetailsRequest model, int? Id)
        {
            
            if(model.Id == Id && Id != 0)
            {
                var record = _context.PatientRecords.FirstOrDefault(x => x.Id == Id);
                if(record != null)
                {
                    if (ModelState.IsValid)
                    {
                        record.DateUpdate = DateTime.UtcNow;
                        record.RecordContext = model.RecordContext;
                        _context.Update(record);
                        _context.SaveChanges();
                        return Ok("Record Updated");
                    }
                }
            }
            return BadRequest();
        }
    }
}
