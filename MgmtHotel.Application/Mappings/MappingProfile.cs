using AutoMapper;
using MgmtHotel.Application.DTOs;
using MgmtHotel.Domain.Entities;

namespace MgmtHotel.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Room, RoomDTO>().ReverseMap();
        }
    }
}
