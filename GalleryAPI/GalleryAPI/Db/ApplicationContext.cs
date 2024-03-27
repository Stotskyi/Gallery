using GalleryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GalleryAPI.Db;

public class ApplicationContext : IdentityDbContext<User,IdentityRole<int>, int>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Image> Images { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }
}