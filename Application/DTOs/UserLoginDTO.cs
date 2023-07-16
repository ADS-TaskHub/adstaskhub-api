using System.ComponentModel.DataAnnotations;
using adstaskhub_api.Domain.Models;

namespace adstaskhub_api.Application.DTOs
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "O campo 'email' é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo 'email' deve ser um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'password' é obrigatório.")]
        public string Password { get; set; }
    }
}
