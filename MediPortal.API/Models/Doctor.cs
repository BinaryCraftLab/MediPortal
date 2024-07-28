using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediPortal.API.Models
{
    public class Doctor :ApplicationUser
    {
        [Required]
        public string Specialization { get; set; }
        public string Bio {  get; set; }
    }
}
