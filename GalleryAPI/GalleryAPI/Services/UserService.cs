using GalleryAPI.Db;
using GalleryAPI.DTO;
using GalleryAPI.Exceptions;
using GalleryAPI.Interfaces;
using GalleryAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GalleryAPI.Services;

public class UserService(UserManager<User> userManager, IJwtService jwtService,IHttpContextAccessor contextAccessor, ApplicationContext context) : IUserService
{
    public async Task<AuthModel> RegisterUserAsync(SignUpModel model)
    {
        var user = new User
        {
            Account = new Account
            {
                Name = model.Username,
                CreatedAt = DateTime.UtcNow,
            },
            UserName = model.Username,
            Email = model.Email
        };

        var result = await userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
        {
            result = await userManager.AddToRoleAsync(user, "User");
            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(user);
                return new AuthModel
                {
                    Roles = roles.ToList(),
                    AccessToken = jwtService.GenerateJwt(user.Id, user.UserName,roles.ToList())
                };
            }
        }
        else
        {
            throw new SignUpFailedException(
                string.Join(",", result.Errors.Select(x => x.Description)));
        }
        
        return null;
    }

    public async Task<AuthModel> LoginUserAsync(SignInModel model)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.UserName == model.Username);
        if (user == null)
            throw new SignInFailedException("User not found");
        var isPasswordValid = await userManager.CheckPasswordAsync(user!, model.Password);

        if (!isPasswordValid)
        {
            throw new SignInFailedException("Password is not valid");
        }

        var roles = await userManager.GetRolesAsync(user);
        
        return new AuthModel
        {
            Roles = roles.ToList(),
            AccessToken = jwtService.GenerateJwt(user.Id, user.UserName!,roles.ToList())
        };
        
    }
}