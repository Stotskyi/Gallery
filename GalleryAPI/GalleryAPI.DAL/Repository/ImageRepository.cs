using GalleryAPI.DAL.Database;
using GalleryAPI.DAL.Models;
using GalleryAPI.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalleryAPI.DAL.Repository;

public class ImageRepository(ApplicationContext dbContext) : IImageRepository
{
    public  async Task<List<Image>> GetAllImagesAsync(int userId)
    {
        var images =  dbContext.Images.Where(i => i.AccountId == userId).ToList();
        
        return await Task.FromResult(images);

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
    
    public async Task DeleteImageAsync(int id)
    {
        var image = dbContext.Images.FindAsync(id).Result;
        dbContext.Images.Remove(image!);
        await dbContext.SaveChangesAsync();
    }
}