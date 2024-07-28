using System.ComponentModel.DataAnnotations;

namespace MediPortal.API.Models.Dto
{
    public class GoogleSignInDto
    {
        [Required]
        public string IdToken { get; set; }
    }
}
