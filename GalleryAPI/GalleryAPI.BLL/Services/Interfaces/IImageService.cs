using GalleryAPI.DAL.Models;

namespace GalleryAPI.BLL.Services.Interfaces;

public interface IImageService
{
    public Task UploadImage(string uri, int id);
    public Task<List<Image>> GetAllImagesAsync(int userId);
}