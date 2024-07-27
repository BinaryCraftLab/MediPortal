using MediPortal.API.Data;
using MediPortal.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly MedicalPortalContext _context;
        public PatientController(MedicalPortalContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAllPatient()
        {
            var patientList = _context.Patients.ToList();
            return Ok(patientList);
        }

        [HttpGet("{PatientNumber}")]
        public IActionResult GetPatientByPatientNumber(string? PatientNumber)
        {
            if (!string.IsNullOrEmpty(PatientNumber))
            {
                var patient  = _context.Patients.FirstOrDefault(x =>x.PatientNumber == PatientNumber);
                if(patient != null)
                {
                    return Ok(patient);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpGet("patientById/{Id}")]
        public IActionResult GetPatientById(int? Id)
        {
            if (Id != 0 || Id != null)
            {
                var patient = _context.Patients.FirstOrDefault(x => x.Id ==  Id);
                if (patient != null)
                {
                    return Ok(patient);
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpDelete("{Id}")]
        public IActionResult DeletePatient(int? Id)
        {
            if (Id != 0 || Id != null)
            {
                var patient = _context.Patients.FirstOrDefault(x => x.Id == Id);
                if (patient != null)
                {
                    _context.Remove(patient);
                    _context.SaveChanges();
                    return Ok("Record Successful deleted");
                }
                return NotFound();
            }
            return BadRequest();
        }
        [HttpPost()]
        public IActionResult AddNewPatient([FromBody] Patient model)
        {
            if (ModelState.IsValid)
            {
                _context.Patients.Add(model);
                _context.SaveChanges();
                return Ok("Patuent record successful added");
            }
            return BadRequest();
        }
        [HttpPut()]
        public IActionResult UpdatePatientDetails([FromBody] Patient model, int? Id)
        {

            if(model.Id == Id && Id != 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Patients.Update(model);
                    _context.SaveChanges();
                    return Ok("Patient record successful updated");
                }
            }
            return BadRequest();
        }

    }
}
