using Azure.Identity;
using GalleryAPI.Interfaces;
using GalleryAPI.Services;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAzureBlobService,AzureBlobService>();
builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration.GetSection("AzureWebJobsStorage"));
    clientBuilder.UseCredential(new DefaultAzureCredential());

});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
