using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models
{
    public enum AppointmentStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class Appointment
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public AppointmentStatus IsApproved { get; set; } = AppointmentStatus.Pending;
        public DateTime AppointmentDate { get; set; }
        public DateTime AppointmentAddDate { get; set; } = DateTime.Now; 
        public string Duration { get; set; }
        public DateTime AppointmentTime { get; set; }

        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
