using System;
using Api.Domain.Dtos.Game;
using Api.Domain.Dtos.Player;

namespace Api.Domain.Dtos.Star
{
    public class StarDtoResult
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public PlayerDtoResult Player { get; set; }

        public Guid GameId { get; set; }
        public GameDtoResult Game { get; set; }
        public int Star { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
