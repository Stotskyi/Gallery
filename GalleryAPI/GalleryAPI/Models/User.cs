using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace GalleryAPI.Models;

[Table(nameof(User))]
public class User : IdentityUser<int>
{
    public int AccountId { get; set; }
    
    public Account Account { get; set; }
   
}