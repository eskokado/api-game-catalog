using System;

namespace Api.Domain.Dtos.Game
{
    public class GameDtoCreateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
    }
}