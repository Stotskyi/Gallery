namespace GalleryAPI.Models;

public class Account
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public DateTime  CreatedAt { get; set; }
    
    public ICollection<Album> Albums { get; set; }
    
    public ICollection<Image> Images { get; set; }
}