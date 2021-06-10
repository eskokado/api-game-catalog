using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Star
{
    public class StarDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Id de Jogador é campo obrigatório")]
        public Guid PlayerId { get; set; }
        [Required(ErrorMessage = "Id de Jogo é campo obrigatório")]
        public Guid GameId { get; set; }
        public int Star { get; set; }
    }
}
