using AutoMapper;
using FirstSpaceApi.Shared.Models;
using static FirstSpaceApi.Shared.DTO.Dto;

namespace FirstSpaceApi.AutoMapper
{
    public class UserToUserDtoProfile : Profile
    {
        public UserToUserDtoProfile() {
            
            // src to des
            CreateMap<User, UserResponseVM>()
               .ForMember(opt => opt.FullName, user => user.MapFrom(u => string.Join(u.FirstName,u.MiddleName ,u.LastName)))
               .ForMember(s => s.FirstName, user => user.MapFrom(u => u.FirstName))
               .ForMember(s => s.MiddleName, user => user.MapFrom(u => u.MiddleName))
               .ForMember(s => s.LastName, user => user.MapFrom(u => u.LastName))
               .ForMember(s => s.Email, user => user.MapFrom(u => u.Email))
               .ForMember(s => s.Password, user => user.MapFrom(u => u.Password))
               .ForMember(s => s.Password, user => user.MapFrom(u => u.Password))
               .ForMember(s => s.Role, user => user.MapFrom(u => u.Role));

            CreateMap<UserRequestVM, User>()
               .ForMember(s => s.FirstName, user => user.MapFrom(u => u.FirstName))
               .ForMember(s => s.MiddleName, user => user.MapFrom(u => u.MiddleName))
               .ForMember(s => s.LastName, user => user.MapFrom(u => u.LastName))
               .ForMember(s => s.Email, user => user.MapFrom(u => u.Email))
               .ForMember(s => s.Password, user => user.MapFrom(u => u.Password))
               .ForMember(s => s.Password, user => user.MapFrom(u => u.Password))
               .ForMember(s => s.Role, user => user.MapFrom(u => u.Role));
        }
            
    }
}
