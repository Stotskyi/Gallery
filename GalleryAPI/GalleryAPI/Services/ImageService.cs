using GalleryAPI.DTO;
using GalleryAPI.Interfaces;
using GalleryAPI.Repo;

namespace GalleryAPI.Services;

public class ImageService(IImageRepository imageRepository) : IImageService
{
    private readonly IImageRepository _imageRepository = imageRepository;

    public async Task UploadImage(string uri, int id)
    { 
        await  _imageRepository.SaveImageAsync(uri, id);
    }

    public async Task<List<ImageDto>> GetAllImagesAsync(int userId)
    {
        var images = await  _imageRepository.GetAllImagesAsync(userId);
        List<ImageDto> imagesDto = images.Select(image => new ImageDto { Uri = image.Uri }).ToList();
        return imagesDto;
    }
}