using AutoMapper;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Core.Persistence.Entities;

namespace Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap <ListingModel, Listing>()
            .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.Reviews, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore()) // since you're setting UserId
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    
        }

    }
}
