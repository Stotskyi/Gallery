using AutoMapper;
using GalleryAPI.Core.DTO;
using GalleryAPI.DAL.Models;

namespace GalleryAPI.Infrastructure.Profiles;

public class ImageProfile : Profile
{
    public ImageProfile()
    {
        CreateMap<Image, ImageDto>()
            .ForMember(
                dest => dest.Id,
                src 
                    => src.MapFrom(x => x.Id))
            .ForMember(
                dest => dest.Uri,
                src 
                => src.MapFrom(x => x.Uri));
         
            
    }   
    
}