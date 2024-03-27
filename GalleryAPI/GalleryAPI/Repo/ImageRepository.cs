using GalleryAPI.Db;
using GalleryAPI.DTO;
using GalleryAPI.Models;

namespace GalleryAPI.Repo;

public class ImageRepository(ApplicationContext dbContext) : IImageRepository
{
    public List<ImageDto> GetAllImagesAsync(int userId)
    {
        var images =  dbContext.Images.Where(i => i.AccountId == userId).ToList();

        var dto = new List<ImageDto>();
        foreach (var i in images)
        {
            dto.Add(new ImageDto
            {
                Uri = i.Uri
            });
        }

        return dto;
    }

    public async Task SaveImageAsync(string uri, int id)
    {
        dbContext.Images.Add(new Image
        {
            Uri = uri,
            AccountId = id
        });
        await dbContext.SaveChangesAsync();
    }
}