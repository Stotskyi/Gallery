using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Models;

namespace GalleryAPI.DAL.Repository.Interfaces;

public interface IAlbumRepository
{
    public Task CreateAlbum(string name, int accountId);

    public Task AddImages(ImagesToAlbumRequest images, int albumId);
    public Task<List<Image>> GetImages(int albumId);
}