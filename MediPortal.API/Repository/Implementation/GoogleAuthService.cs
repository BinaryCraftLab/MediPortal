using MediPortal.API.Data;
using MediPortal.API.Models;
using MediPortal.API.Models.Dto;
using MediPortal.API.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace MediPortal.API.Repository.Implementation
{
    public class GoogleAuthService 
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly MedicalPortalContext _medicalPortalContext;
        private readonly GoogleAuthConfig _googleAuthConfig;

        public GoogleAuthService(UserManager<ApplicationUser> userManager,
            MedicalPortalContext medicalPortalContext, 
            GoogleAuthConfig googleAuthConfig)
        {
            _userManager = userManager;
            _medicalPortalContext = medicalPortalContext;
            _googleAuthConfig = googleAuthConfig;
        }

    }
}
