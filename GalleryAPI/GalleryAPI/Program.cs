using System.Text;
using Azure.Identity;
using GalleryAPI.BLL.Services;
using GalleryAPI.BLL.Services.Interfaces;
using GalleryAPI.DAL.Database;
using GalleryAPI.DAL.Models;
using GalleryAPI.DAL.Options;
using GalleryAPI.DAL.Repository;
using GalleryAPI.DAL.Repository.Interfaces;
using GalleryAPI.Infrastructure.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(typeof(ImageProfile));
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAzureBlobService,AzureBlobService>();
builder.Services.AddScoped<IImageService, ImageService>();

builder.Services.AddDbContext<ApplicationContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
    opts.EnableSensitiveDataLogging();
});
builder.Services.AddIdentity<User, IdentityRole<int>>(opts => opts.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole<int>>()
    .AddTokenProvider<DataProtectorTokenProvider<User>>("GalleryAPI.B")
    .AddEntityFrameworkStores<ApplicationContext>()
    .AddDefaultTokenProviders();

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
        AuthenticationType = "Jwt",
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
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Owner", policy => policy.RequireRole("Owner"));
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("User", policy => policy.RequireRole("User"));
});

builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("AzureWebJobsStorage"));
    clientBuilder.UseCredential(new DefaultAzureCredential());

});

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.Configure<OwnerOptions>(builder.Configuration.GetSection(nameof(OwnerOptions)));


var app = builder.Build();
app.MapControllers();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
});

app.Run();


