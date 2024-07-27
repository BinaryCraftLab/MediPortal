using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models
{
    public class PatientRecord
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate {get; set; }
        public string RecordContext { get; set; }
        public string DoctorName { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
    }
}
