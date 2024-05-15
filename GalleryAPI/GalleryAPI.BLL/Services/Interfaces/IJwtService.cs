namespace GalleryAPI.BLL.Services.Interfaces;

public interface IJwtService
{
    public string GenerateJwt(int userId, string username, List<string> roles);
}