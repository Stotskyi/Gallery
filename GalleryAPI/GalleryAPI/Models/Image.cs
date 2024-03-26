namespace GalleryAPI.Models;

public class Image
{
    public string Id { get; set; }
    public string Uri { get; set; }
    
    public User User { get; set; }
    public string UserId { get; set; }
    
    public ICollection<Album> Albums;
}