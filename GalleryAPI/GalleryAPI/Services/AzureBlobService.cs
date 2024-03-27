using System.Text;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using GalleryAPI.Interfaces;
using GalleryAPI.Repo;
using Microsoft.AspNetCore.Http.HttpResults;

namespace GalleryAPI.Services;

public class AzureBlobService :  IAzureBlobService
{
    private readonly  BlobServiceClient _blobCliet;
    private readonly BlobContainerClient _containerClient;
    private readonly IImageRepository _imageContext;
        
    public AzureBlobService(BlobServiceClient blobClient,IConfiguration configuration, IImageRepository imageContext)
    {
        _blobCliet = blobClient;
        _imageContext = imageContext;
        _containerClient = _blobCliet.GetBlobContainerClient(configuration.GetValue<string>("BlobContainerName"));
    }

    public async Task<String> UploadFilesAsync(IFormFile file, int id)
    {
        var fileName = new StringBuilder($"{id}/{file.FileName}").ToString();
        BlobClient client = _containerClient.GetBlobClient(fileName);
        var streamContent = file.OpenReadStream();
       
        var responseFromUploading = await _containerClient.UploadBlobAsync(fileName, streamContent, default);

      //  await SetMetadataAsync(fileName, "userid");
        await _imageContext.SaveImageAsync(client.Uri.ToString(), id);
       
        return client.Uri.ToString();
    }

    public async Task<Response<BlobInfo>> SetMetadataAsync(string fileName,string uri)
    {
        BlobClient client = _containerClient.GetBlobClient(fileName);
        try
        {
            IDictionary<string, string> metadata =
                new Dictionary<string, string>();

            metadata.Add("userid", uri);
            return  await client.SetMetadataAsync(metadata);
        }
        catch (RequestFailedException e)
        {
            return null;
        }
    }
    
    
   
}