using System;

namespace Api.Domain.Entities
{
    public class StarEntity : BaseEntity
    {
        public Guid PlayerId { get; set; }

        public Guid GameId { get; set; }

        public int Star { get; set; }
    }
}
