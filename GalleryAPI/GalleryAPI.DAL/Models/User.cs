using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GalleryAPI.DAL.Models;

[Table(nameof(User))]
public class User : IdentityUser<int>
{
    public int AccountId { get; set; }
    
    public Account Account { get; set; }
   
}