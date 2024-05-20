using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Models;
using GalleryAPI.DAL.Repository.Interfaces;

namespace GalleryAPI.BLL.Services;

public class AlbumService(IAlbumRepository albumRepository) : IAlbumService
{
    public async Task CreateAlbumAsync(string name, int accountId)
    {
       await  albumRepository.CreateAlbum(name, accountId);

    }

    public async Task UploadImages(ImagesToAlbumRequest imagesDto, int albumId)
    {
        await albumRepository.AddImages(imagesDto, albumId);
    }

    public async Task<List<Image>> GetImages(int albumId)
    {
       var images =  await albumRepository.GetImages(albumId);
       return images;
    }
}