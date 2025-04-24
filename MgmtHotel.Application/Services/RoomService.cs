using AutoMapper;
using MgmtHotel.Application.DTOs;
using MgmtHotel.Application.Interfaces;
using MgmtHotel.Domain.Entities;
using MgmtHotel.Domain.Interfaces;
using MgmtHotel.Domain.Pagination;

namespace MgmtHotel.Application.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        public async Task Update(RoomDTO roomDTO)
        {
            try
            {
                var room = _mapper.Map<Room>(roomDTO);

                await _roomRepository.Update(room);
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var room = await _roomRepository.Get(id);

                await _roomRepository.Delete(room);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task Insert(RoomDTO roomDTO)
        {
            try
            {
                var room = _mapper.Map<Room>(roomDTO);
                var returnRoom = await _roomRepository.GetRoomByNumber(room.RoomNumber);

                if (returnRoom != null)
                    throw new Exception("Quarto já existe na base de dados.");

                await _roomRepository.Create(room);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RoomDTO> GetAsync(int id)
        {
            var room = await _roomRepository.Get(id);
            var roomDTO = _mapper.Map<RoomDTO>(room);

            return roomDTO;
        }

        public Task<PagedList<RoomDTO>> GetByFilterAsync(string termo, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<RoomDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
