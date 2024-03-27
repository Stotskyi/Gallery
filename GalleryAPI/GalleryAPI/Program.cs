using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Azure.Identity;
using GalleryAPI.Db;
using GalleryAPI.DTO;
using GalleryAPI.Interfaces;
using GalleryAPI.Models;
using GalleryAPI.Options;
using GalleryAPI.Repo;
using GalleryAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthorization();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAzureBlobService,AzureBlobService>();
builder.Services.AddDbContext<ApplicationContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});
builder.Services.AddIdentity<User, IdentityRole<int>>(opts => opts.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationContext>();
builder.Services.Configure<IdentityOptions>(opts =>
{
    opts.Password.RequireDigit = true;
    opts.Password.RequireLowercase = true;
    opts.Password.RequireUppercase = true;
    opts.Password.RequiredLength = 6;
    opts.Password.RequireNonAlphanumeric = true;
    opts.Password.RequiredUniqueChars = 1;
    
    opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opts.Lockout.MaxFailedAccessAttempts = 5;
    opts.Lockout.AllowedForNewUsers = true;
    
    opts.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    opts.User.RequireUniqueEmail = false;
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
        ValidAudience = builder.Configuration["JwtOptions:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
            (Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"]!)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("AzureWebJobsStorage"));
    clientBuilder.UseCredential(new DefaultAzureCredential());

});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddAntiforgery();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
//app.MapControllers();

app.MapPost("sign-up", ([FromServices] IUserService userService,
    [FromBody] SignUpModel model) => userService.RegisterUserAsync(model));

app.MapPost("sign-in", ([FromServices] IUserService userService,
    [FromBody] SignInModel model) => userService.LoginUserAsync(model));

app.MapGet("me", ([FromServices] IHttpContextAccessor accessor, IImageRepository _imageContext) =>
{
    var id =  accessor.HttpContext?.User.Claims
        .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)? 
        .Value;
   
     Int32.TryParse(id, out int res);
     var users =  _imageContext.GetAllImagesAsync(res);

     List<string> images = null;
     foreach (var u in users)
     {
         images.Add(u.Uri);
     }

     return images; 

}).RequireAuthorization();

app.MapPost("upload-file", async ([FromServices] IHttpContextAccessor accessor, IAzureBlobService _azureBlobService,  IFormFile file) =>
    {
        var id = accessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?
            .Value;
        Int32.TryParse(id, out int res);
      var uri =  await  _azureBlobService.UploadFilesAsync(file, res);
      return uri;
    }).RequireAuthorization().DisableAntiforgery();
app.Run();
