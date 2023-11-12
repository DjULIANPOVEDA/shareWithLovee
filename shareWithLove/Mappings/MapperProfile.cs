using AutoMapper;
using shareWithLove.Models;
using shareWithLove.Models.Request;
using shareWithLove.Models.Response;

namespace shareWithLove.Mappings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<RegisterRequest, User>();


            CreateMap<DonationResponse, Clothe>();
            CreateMap<DonationRequest, Clothe>();
            CreateMap<Clothe, DonationWithUserResponse>();
            CreateMap<Clothe, DonationResponse>();
            CreateMap<Clothe, DonationRequest>();
        }
    }
}

