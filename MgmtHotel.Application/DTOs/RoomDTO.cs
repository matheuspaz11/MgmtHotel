using MgmtHotel.Domain.Entities.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MgmtHotel.Application.DTOs
{
    public class RoomDTO
    {
        [JsonPropertyName("RoomNumber")]
        [Required(ErrorMessage = "O número do quarto é obrigatório")]
        [StringLength(3, ErrorMessage = "O número do quarto deve ter no máximo 3 dígitos")]
        public string RoomNumber { get; set; } = string.Empty;

        [JsonPropertyName("NumberOccupants")]
        [Required(ErrorMessage = "O número de ocupantes é obrigatório")]
        [Range(1, 5, ErrorMessage = "Número de ocupantes máximo é 5")]
        public int NumberOccupants { get; set; }

        [JsonPropertyName("Available")]
        public bool Available { get; set; } = true;

        [JsonPropertyName("Clean")]
        public bool Clean { get; set; } = true;

        [JsonPropertyName("AdditionalBed")]
        [Required(ErrorMessage = "O campo cama adicional é obrigatório")]
        public bool? AdditionalBed { get; set; }

        [JsonPropertyName("RoomFull")]
        [Required(ErrorMessage = "O campo quarto completo é obrigatório")]
        public bool? RoomFull { get; set; }

        [JsonPropertyName("BedType")]
        [Required(ErrorMessage = "O campo tipo de cama é obrigatório")]
        [Range(0, 2, ErrorMessage = "O tipo de cama deve ser 0 (Casal), 1 (Solteiro) ou 2 (Beliche).")]
        public BetType BedType { get; set; }

        [JsonPropertyName("Observation")]
        [MaxLength(100, ErrorMessage = "O campo observação deve ter no máximo 100 dígitos")]
        public string? Observation { get; set; } = string.Empty;
    }
}
