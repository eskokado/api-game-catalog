using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Star
{
    public class StarDtoCreate
    {
        [Required(ErrorMessage = "Id de Jogador é campo obrigatório")]
        public Guid PlayerId { get; set; }
        [Required(ErrorMessage = "Id de Jogo é campo obrigatório")]
        public Guid GameId { get; set; }
        [Required(ErrorMessage = "Star é campo obrigatório, favor informar valor de 0 a 10")]
        [Range(0,10)]
        public int Star { get; set; }
    }
}
