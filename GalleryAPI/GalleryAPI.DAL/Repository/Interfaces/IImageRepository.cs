using GalleryAPI.DAL.Models;

namespace GalleryAPI.DAL.Repository.Interfaces;

public interface IImageRepository
{
    public Task<List<Image>> GetAllImagesAsync(int userId);
    public Task SaveImageAsync(string uri, int id);
    public Task DeleteImageAsync(int id);
}