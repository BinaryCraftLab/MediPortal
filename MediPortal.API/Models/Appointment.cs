using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DoctorName { get; set; }
        public string IsApproved { get; set; }
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmnentAddDate { get; set; }
        public double Duration { get; set; }
        public DateTime AppointmentTime { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
