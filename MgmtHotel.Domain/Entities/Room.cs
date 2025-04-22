using MgmtHotel.Domain.Entities.Enum;

namespace MgmtHotel.Domain.Entities
{
    public sealed class Room : BaseEntity
    {
        public string RoomNumber { get; set; }

        public int NumberOccupants { get; set; }

        public bool Available { get; set; }

        public bool Clean {  get; set; }

        public bool AdditionalBed { get; set; }

        public bool RoomFull { get; set; }

        public BetType BedType { get; set; }

        public string? Observation { get; set; } = string.Empty;
    }
}
