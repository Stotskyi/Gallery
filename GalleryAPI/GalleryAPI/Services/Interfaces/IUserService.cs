using GalleryAPI.DTO;

namespace GalleryAPI.Interfaces;

public interface IUserService
{
    Task<AuthModel> RegisterUserAsync(SignUpModel model);
    Task<AuthModel> LoginUserAsync(SignInModel model);
}