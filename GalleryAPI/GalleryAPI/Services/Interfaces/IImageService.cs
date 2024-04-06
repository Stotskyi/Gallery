using GalleryAPI.DTO;

namespace GalleryAPI.Interfaces;

public interface IImageService
{
    public Task UploadImage(string uri, int id);
    public Task<List<ImageDto>> GetAllImagesAsync(int userId);
}