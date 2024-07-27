using MediPortal.API.Data;
using MediPortal.API.Models;
using MediPortal.API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly MedicalPortalContext _context;
        public AppointmentController(MedicalPortalContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllAppointments() { 
           var appointments  = _context.Appointments.ToList();
            return Ok(appointments);
        }

        [HttpPost]
        public IActionResult AddAppointmentSchedule([FromBody] AddAppointmentRequest model)
        {
            if (ModelState.IsValid)
            {
                var obj = new Appointment
                {
                    DoctorName = model.DoctorName,
                    AppointmentDate = model.AppointmentDate,
                    Duration = model.Duration,
                    AppointmentTime = model.AppointmentTime,
                    PatientId = model.PatientId,
                    IsApproved = "Pending",
                    AppointmnentAddDate  = DateTime.Now,
                };
                _context.Appointments.Add(obj);
                _context.SaveChanges();
                return Ok("Appointment successful added");
            }
            return BadRequest();
        }
    }
}
