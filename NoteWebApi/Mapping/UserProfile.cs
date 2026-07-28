using AutoMapper;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;

namespace NoteWebApi.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>()
                .ForMember(dect => dect.PasswordHash, opt => opt.MapFrom(src => BCrypt.Net.BCrypt.HashPassword(src.Password)))
                .ForMember(dect => dect.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
            CreateMap<User, ResultUserDto>();
        }
    }
}
