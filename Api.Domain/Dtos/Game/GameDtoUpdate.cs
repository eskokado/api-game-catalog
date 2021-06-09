using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Game
{
    public class GameDtoUpdate
    {
        [Required(ErrorMessage = "Id é campo obrigatório para Login")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome é campo obrigatório para Login")]
        [StringLength(100, ErrorMessage ="Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }
    }
}