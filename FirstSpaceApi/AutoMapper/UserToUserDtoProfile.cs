using AutoMapper;
using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;

namespace FirstSpaceApi.AutoMapper
{
    public class UserToUserDtoProfile : Profile
    {
        public UserToUserDtoProfile() {
            
            // src to des
            CreateMap<User, UserVM>()
                .ForCtorParam("FullName", user => user.MapFrom(u => string.Join(u.FirstName,u.MiddleName ,u.LastName)));

        }
            
    }
}
