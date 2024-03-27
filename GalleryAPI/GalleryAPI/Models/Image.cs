using System.ComponentModel.DataAnnotations.Schema;

namespace GalleryAPI.Models;

public class Image
{
    public int Id { get; set; }
    public string Uri { get; set; }
    
    public Account Account { get; set; }
    public int AccountId { get; set; }
    
    public ICollection<Album> Albums;
}