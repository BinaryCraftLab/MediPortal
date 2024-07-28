using MediPortal.API.Data;
using MediPortal.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]
    public class MedicationScheduleController : ControllerBase
    {
        private readonly MedicalPortalContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MedicationScheduleController(MedicalPortalContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // POST: api/MedicationSchedule
        [HttpPost]
        public async Task<IActionResult> CreateMedicationSchedule([FromBody] MedicationSchedule model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var currentDate = DateTime.UtcNow;

            // Set the given date to the current date if it's not set
            model.GivenDate = currentDate;

            // Validate if the end date is after the given date
            if (model.GivenDate > model.EndDate)
            {
                return BadRequest("End date must be after the given date.");
            }

            var schedules = GenerateMedicationSchedules(model);

            foreach (var schedule in schedules)
            {
                schedule.DoctorId = _httpContextAccessor.HttpContext.User.Identity.Name; // Set the current doctor's ID
                _context.MedicationSchedules.Add(schedule);
            }

            await _context.SaveChangesAsync();
            return Ok("Medication schedule successfully added.");
        }

        private IEnumerable<MedicationSchedule> GenerateMedicationSchedules(MedicationSchedule model)
        {
            var schedules = new List<MedicationSchedule>();

            for (var date = model.GivenDate.Date; date <= model.EndDate.Date; date = date.AddDays(1))
            {
                var dailySchedules = Enumerable.Range(0, model.NumberOfInTakePerDay)
                    .Select(index => new MedicationSchedule
                    {
                        PatientId = model.PatientId,
                        GivenDate = model.GivenDate,
                        EndDate = model.EndDate,
                        NumberOfInTakePerDay = model.NumberOfInTakePerDay,
                        DrinkTime = GetDailyMedicationTime(date, model.NumberOfInTakePerDay, index),
                        DoctorId = model.DoctorId
                    });

                schedules.AddRange(dailySchedules);
            }

            return schedules;
        }

        private DateTime GetDailyMedicationTime(DateTime date, int numberOfInTakePerDay, int index)
        {
            TimeSpan[] intakeTimes = numberOfInTakePerDay switch
            {
                1 => new[] { new TimeSpan(8, 0, 0) }, // 08:00 AM
                2 => new[] { new TimeSpan(8, 0, 0), new TimeSpan(17, 0, 0) }, // 08:00 AM and 05:00 PM
                3 => new[] { new TimeSpan(8, 0, 0), new TimeSpan(12, 0, 0), new TimeSpan(17, 0, 0) }, // 08:00 AM, 12:00 PM, 05:00 PM
                _ => throw new ArgumentOutOfRangeException()
            };

            return date.Date.Add(intakeTimes[index]);
        }
    }
}
