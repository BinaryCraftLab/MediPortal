using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models.Dto
{
    public class AddAppointmentRequest
    {
        public required string DoctorName { get; set; }
        public required DateTime AppointmentDate { get; set; }
        public required string Duration { get; set; }
        public required DateTime AppointmentTime { get; set; }
        public required int PatientId { get; set; }
    }
}
