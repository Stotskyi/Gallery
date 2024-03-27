using GalleryAPI.DTO;
using GalleryAPI.Models;

namespace GalleryAPI.Repo;

public interface IImageRepository
{
    public List<ImageDto> GetAllImagesAsync(int userId);
    public Task SaveImageAsync(string uri, int id);
}