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
                return BadRequest( new { message = ex.Message });
            }
        }
    }
}
