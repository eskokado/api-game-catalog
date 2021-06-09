using System;

namespace Api.Domain.Dtos.Player
{
    public class PlayerDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        public DateTime CreateAt { get; set; }
    }
}