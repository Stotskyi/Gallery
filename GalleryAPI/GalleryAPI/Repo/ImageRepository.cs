using GalleryAPI.Db;
using GalleryAPI.DTO;
using GalleryAPI.Models;

namespace GalleryAPI.Repo;

public class ImageRepository(ApplicationContext dbContext) : IImageRepository
{
    public  async Task<List<Image>> GetAllImagesAsync(int userId)
    {
        var images =  dbContext.Images.Where(i => i.AccountId == userId).ToList();

        var dto = images.Select(i => new Image
        {
            Uri = i.Uri
        }).ToList();

        return await Task.FromResult(dto);

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