using GalleryAPI.Db.Model;
using GalleryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GalleryAPI.Db;

public class ApplicationContext : IdentityDbContext<User,IdentityRole<int>, int>
{
    private readonly OwnerOptions _ownerOptions;
    public ApplicationContext(DbContextOptions<ApplicationContext> options, IOptions<OwnerOptions> ownerOptions)
        : base(options)
    {
        _ownerOptions = ownerOptions.Value;
        Database.Migrate();
    }

    public DbSet<Image> Images { get; set; }
    public DbSet<Album> Albums { get; set; }
    public DbSet<Account> Accounts { get; set; } 
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        const int ownerRoleId = 1;
        const int adminRoleId = 2;
        const int userRoleId = 3;

        base.OnModelCreating(builder);
        var roles = new List<IdentityRole<int>>
        {
            new IdentityRole<int>()
            {
                Id = ownerRoleId,
                Name = "Owner",
                NormalizedName = "Owner".ToUpper(),
                ConcurrencyStamp = ownerRoleId.ToString()
            },
            new IdentityRole<int>()
            {
            Id = adminRoleId,
            Name = "Admin",
            NormalizedName = "Admin".ToUpper(),
            ConcurrencyStamp = adminRoleId.ToString()
             },
            new IdentityRole<int>()
            {
                Id = userRoleId,
                Name = "User",
                NormalizedName = "User".ToUpper(),
                ConcurrencyStamp = userRoleId.ToString()
            }
        };

        builder.Entity<IdentityRole<int>>().HasData(roles);
       
        builder.Entity<Account>().HasData(
            new Account { Id = 3, Name = _ownerOptions.UserName, CreatedAt = DateTime.UtcNow });

       var owner =  new User
       {
           Id = _ownerOptions.Id,
           UserName = _ownerOptions.UserName,
           Email = _ownerOptions.Email,
           NormalizedEmail = _ownerOptions.Email.ToUpper(),
           NormalizedUserName = _ownerOptions.UserName.ToUpper(),
           AccountId = 3
           
       };
        owner.PasswordHash = new PasswordHasher<User>().HashPassword(owner, _ownerOptions.Password);
       
        builder.Entity<User>().HasData(owner);

        var ownerRoles = new List<IdentityUserRole<int>>()
        {
            new()
            {
                UserId = 3,
                RoleId = ownerRoleId
            }
        };
        builder.Entity<IdentityUserRole<int>>().HasData(ownerRoles);
    }
}