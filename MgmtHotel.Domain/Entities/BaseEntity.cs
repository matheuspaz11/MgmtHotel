﻿namespace MgmtHotel.Domain.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime? DeletionDate { get; set; } = null;
    }
}
