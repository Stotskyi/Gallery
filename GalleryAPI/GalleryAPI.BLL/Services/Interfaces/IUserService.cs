using GalleryAPI.PL.DTO;

namespace GalleryAPI.BLL.Services.Interfaces;

public interface IUserService
{
    Task<AuthModel> RegisterUserAsync(SignUpModel model);
    Task<AuthModel> LoginUserAsync(SignInModel model);
}