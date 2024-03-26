namespace GalleryAPI.Models;

public class Album
{
    public string Id { get; set; }
    
    public User User { get; set; }
    public string UserId { get; set; }
    
    public ICollection<Image> Images { get; set; }
}