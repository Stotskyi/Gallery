using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Models;

namespace GalleryAPI.BLL.Services.Interfaces;

public interface IAlbumService
{
    public Task CreateAlbumAsync(string name, int accountId);

    public Task UploadImages(ImagesToAlbumRequest imagesDto, int albumId);
    public Task<List<Image>> GetImages(int albumId);
}