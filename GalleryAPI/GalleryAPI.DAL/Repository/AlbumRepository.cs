using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Database;
using GalleryAPI.DAL.Models;
using GalleryAPI.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalleryAPI.DAL.Repository;

public class AlbumRepository(ApplicationContext dbContext) : IAlbumRepository
{
    public async Task CreateAlbum(string name, int accountId)
    {
        var album = new Album
        {
            Name = name,
            AccountId = accountId
        };
        dbContext.Albums.Add(album);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddImages(ImagesToAlbumRequest images, int albumId)
    {
        var album = dbContext.Albums.FindAsync(albumId).Result;
        var imagesToAdd = dbContext.Images.Where(img => images.ImagesIds.Contains(img.Id));
        foreach (var i in imagesToAdd )
        {
            album.Images.Add(i);
        }

        await dbContext.SaveChangesAsync();
    }

    public Task<List<Image>> GetImages(int albumId)
    {
        var images = dbContext.Albums.Where(a => a.Id == albumId)
            .SelectMany(a => a.Images)
            .ToListAsync();

        return images;
    }

}