namespace GalleryAPI.Interfaces;

public interface IJwtService
{
    public string GenerateJwt(int userId,string username);
}