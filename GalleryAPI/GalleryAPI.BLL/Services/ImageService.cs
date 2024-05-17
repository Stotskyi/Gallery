using AutoMapper;
using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Models;
using GalleryAPI.DAL.Repository.Interfaces;

namespace GalleryAPI.BLL.Services;

public class ImageService(IImageRepository imageRepository,IMapper _mapper) : IImageService
{
    public async Task UploadImage(string uri, int id)
    { 
        await  imageRepository.SaveImageAsync(uri, id);
    }

    public async Task<List<ImageDto>> GetAllImagesAsync(int userId)
    {
        var images = await  imageRepository.GetAllImagesAsync(userId);
        return  _mapper.Map<List<Image>, List<ImageDto>>(images);
    }

    public async Task DeleteImageAsync(int id)
    {
        await imageRepository.DeleteImageAsync(id);
    }
}