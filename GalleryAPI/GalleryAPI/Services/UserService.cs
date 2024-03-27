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

        if (!result.Succeeded)
        {
            throw new SignUpFailedException(
                string.Join(",", result.Errors.Select(x => x.Description)));
        }

        return new AuthModel
        {
            AccessToken = jwtService.GenerateJwt(user.Id, user.UserName)
        };
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
        
        return new AuthModel
        {
            AccessToken = jwtService.GenerateJwt(user.Id, user.UserName!)
        };
        
    }
}