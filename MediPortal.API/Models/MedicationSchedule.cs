using System.ComponentModel.DataAnnotations.Schema;

namespace MediPortal.API.Models
{
    public class MedicationSchedule
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Patient))]
        public string PatientId { get; set; }
        public Patient Patient { get; set; }
        public DateTime GivenDate { get; set; }
        public DateTime EndDate { get; set; }
        //Number of time that the partient must drink the medication
        //if 1 means patient must drink one times a day at 08:00 in the morning
        //if 2 means parient must drink two times a day at 08:00 and 17:00
        //if 3 mean patient must drink three times a day at 08:00 ,12:00, 17:00
        public int NumberOfInTakePerDay { get; set; }
        public DateTime DrinkTime { get; set; }
        [ForeignKey(nameof(Doctor))]
        public string DoctorId {  get; set; }
        public  Doctor Doctor { get; set; }
    }
}
