using Microsoft.AspNetCore.Identity;

namespace MediPortal.API.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string Speciality { get; set; }
        public string ProfileImageUrl { get; set; }

    }
}
