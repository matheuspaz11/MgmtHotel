namespace MgmtHotel.Domain.Entities
{
    public sealed class Room : BaseEntity
    {
        public string RoomNumber { get; set; } = string.Empty;

        public int NumberOccupants { get; set; }

        public bool Available { get; set; }

        public bool Clean {  get; set; }

        public bool AdditionalBed { get; set; }

        public bool RoomFull { get; set; }

        public char BedType { get; set; }
    }
}
