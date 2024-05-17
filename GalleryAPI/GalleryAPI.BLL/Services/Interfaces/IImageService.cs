using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Models;

namespace GalleryAPI.BLL.Services.Interfaces;

public interface IImageService
{
    public Task UploadImage(string uri, int id);
    public Task<List<ImageDto>> GetAllImagesAsync(int userId);
    public Task DeleteImageAsync(int id);
}