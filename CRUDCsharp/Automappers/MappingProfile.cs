using AutoMapper;
using CRUDCsharp.Dtos;
using CRUDCsharp.Models;

namespace CRUDCsharp.Automappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<UserInsertDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Id,
                m => m.MapFrom(u => u.Id));
        }
    }
}
