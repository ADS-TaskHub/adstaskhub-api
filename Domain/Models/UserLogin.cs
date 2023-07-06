using System.ComponentModel.DataAnnotations;

namespace adstaskhub_api.Domain.Models
{
    public class UserLogin : EntityBase
    {
        [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo 'email' deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'password' é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public string Password { get; set; }
    }
}
