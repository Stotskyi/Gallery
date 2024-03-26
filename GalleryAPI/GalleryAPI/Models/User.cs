namespace GalleryAPI.Models;

public class User
{
    public string Id { get; set; }
    public string Name { get; set; }
    
    public ICollection<Album> Albums { get; set; }
    public ICollection<Image> Images { get; set; }
}