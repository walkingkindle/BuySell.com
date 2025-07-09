using AutoMapper;
using BuySellDotCom.Application.Models;
using BuySellDotCom.Application.Models.BaseTypes;
using BuySellDotCom.Application.Models.DTO;
using BuySellDotCom.Core.Persistence.Entities;

namespace Infrastructure
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap <ListingModel, Listing>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.Reviews, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ListingDto, ListingModel>();

            CreateMap<AddressModel, Address>();

            CreateMap<ReviewModel, Review>();

        }

    }
}
