namespace GalleryAPI.Models;

public class Album
{
    public int Id { get; set; }
    
    public Account Account { get; set; }
    public int AccountId { get; set; }
    
    public ICollection<Image> Images { get; set; }
}