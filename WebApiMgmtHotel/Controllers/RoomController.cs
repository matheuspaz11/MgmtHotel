using MgmtHotel.Application.DTOs;
using MgmtHotel.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MgmtHotel.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] RoomDTO roomDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new InvalidOperationException();

                await _roomService.Insert(roomDTO);

                return Ok(new { message = "Quarto inserido com sucesso!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest(new { message = "Id deve ser maior que zero" });

                var room = await _roomService.GetAsync(id);

                if (room == null)
                    return BadRequest(new { message = "Quarto não encontrado" });

                return Ok(room);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest(new { message = "Id deve ser maior que zero" });

                var room = await _roomService.GetAsync(id);

                if (room == null)
                    return BadRequest(new { message = "Quarto não encontrado" });

                await _roomService.Delete(id);

                return Ok(new { message = "Quarto excluído com sucesso" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<ActionResult> Update([FromQuery]int id, [FromBody] RoomUpdateDTO roomUpdateDTO)
        {
            try
            {
                if (id == 0)
                    return BadRequest(new { message = "Id deve ser maior que zero." });

                var room = await _roomService.GetAsync(id);

                if (room == null)
                    return NotFound(new { message = "Quarto não encontrado." });

                var roomUpdated = await _roomService.Update(roomUpdateDTO, room);

                return Ok(new { message = "Quarto atualizado com sucesso.", roomUpdated });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("PagedRooms")]
        public async Task<ActionResult> GetPagedRooms([FromQuery] int pageNumber, [FromQuery] int pageSize)
        {
            try
            {
                var rooms = await _roomService.GetPagedRoomsAsync(pageNumber, pageSize);

                if (rooms == null)
                    return BadRequest(new { message = "Nenhum quarto encontrado." });

                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
