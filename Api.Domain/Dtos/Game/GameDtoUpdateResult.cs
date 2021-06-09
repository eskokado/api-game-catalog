using System;

namespace Api.Domain.Dtos.Game
{
    public class GameDtoUpdateResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}