using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.Player
{
    public class PlayerDtoCreate
    {
        [Required(ErrorMessage = "Nome é campo obrigatório para Login")]
        [StringLength(100, ErrorMessage ="Nome deve ter no máximo {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é campo obrigatório para Login")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {1} caracteres")]
        public string Email { get; set; }
    }
}