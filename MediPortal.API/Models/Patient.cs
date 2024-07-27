using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public required string PatientNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Address  { get; set; }
        public string DateOfBirth { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinPhone { get; set; }
        public ICollection<PatientRecord> PatientRecords { get; set; }
    }
}
