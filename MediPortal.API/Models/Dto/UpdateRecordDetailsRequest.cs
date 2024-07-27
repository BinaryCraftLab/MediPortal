namespace MediPortal.API.Models.Dto
{
    public class UpdateRecordDetailsRequest
    {
        public int Id { get; set; }
        public required string RecordContext { get; set; }
    }
}
