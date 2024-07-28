using MediPortal.API.Models;
using MediPortal.API.Models.Dto;

namespace MediPortal.API.Repository.IRepository
{
    public interface IGoogleAuthService
    {
        Task<BaseResponse<ApplicationUser>> GoogleSignIn(GoogleSignInDto model);
    }
}
