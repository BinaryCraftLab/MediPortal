using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models
{
    public class Patient: ApplicationUser
    {
        public required string PatientNumber { get; set; }
        public int Age { get; set; }
        public string DateOfBirth { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinPhone { get; set; }
        public ICollection<PatientRecord> PatientRecords { get; set; }
    }
}
