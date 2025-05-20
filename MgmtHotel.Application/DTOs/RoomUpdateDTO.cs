using MgmtHotel.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MgmtHotel.Application.DTOs
{
    public class RoomUpdateDTO
    {
        [JsonPropertyName("NumberOccupants")]
        [Range(1, 5, ErrorMessage = "Número de ocupantes máximo é 5")]
        public int? NumberOccupants { get; set; }

        [JsonPropertyName("AdditionalBed")]
        public bool? AdditionalBed { get; set; }

        [JsonPropertyName("RoomFull")]
        public bool? RoomFull { get; set; }

        [JsonPropertyName("BedType")]
        [Range(0, 2, ErrorMessage = "O tipo de cama deve ser 0 (Casal), 1 (Solteiro) ou 2 (Beliche).")]
        public BedType? BedType { get; set; }

        [JsonPropertyName("Observation")]
        [MaxLength(100, ErrorMessage = "O campo observação deve ter no máximo 100 dígitos")]
        public string? Observation { get; set; }
    }
}
