using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models.Dto
{
    public class AddNewPatientRequest
    {
        public required string RecordContext { get; set; }
        public required string DoctorName { get; set; }
        public required int PatientId { get; set; }
    }
}
