using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MgmtHotel.Application.DTOs
{
    public class RoomDTO
    {
        [JsonPropertyName("RoomNumber")]
        [Required(ErrorMessage = "O número do quarto é obrigatório")]
        [StringLength(3)]
        public string RoomNumber { get; set; } = string.Empty;

        [JsonPropertyName("NumberOccupants")]
        [Required(ErrorMessage = "O número de ocupantes é obrigatório")]
        public int NumberOccupants { get; set; }

        [JsonPropertyName("Available")]
        public bool Available { get; set; }

        [JsonPropertyName("Clean")]
        public bool Clean { get; set; }

        [JsonPropertyName("AdditionalBed")]
        [Required(ErrorMessage = "O campo cama adicional é obrigatório")]
        public bool AdditionalBed { get; set; }

        [JsonPropertyName("RoomFull")]
        [Required(ErrorMessage = "O campo quarto completo é obrigatório")]
        public bool RoomFull { get; set; }

        [JsonPropertyName("BedType")]
        [Required(ErrorMessage = "O campo tipo de cama é obrigatório")]
        public int BedType { get; set; }
    }
}
