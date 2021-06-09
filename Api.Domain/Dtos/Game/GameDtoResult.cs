using System;

namespace Api.Domain.Dtos.Game
{
    public class GameDtoResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}