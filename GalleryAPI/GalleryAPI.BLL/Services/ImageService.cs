using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.DAL.Models;
using GalleryAPI.DAL.Repository.Interfaces;

namespace GalleryAPI.Services;

public class ImageService(IImageRepository imageRepository) : IImageService
{
    private readonly IImageRepository _imageRepository = imageRepository;

    public async Task UploadImage(string uri, int id)
    { 
        await  _imageRepository.SaveImageAsync(uri, id);
    }

    public async Task<List<Image>> GetAllImagesAsync(int userId)
    {
        var images = await  _imageRepository.GetAllImagesAsync(userId);
        return images;
    }
}