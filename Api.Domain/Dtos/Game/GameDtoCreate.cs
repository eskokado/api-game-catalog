using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Game
{
    public class GameDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório para Login")]
        [StringLength(100, ErrorMessage ="Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }
    }
}