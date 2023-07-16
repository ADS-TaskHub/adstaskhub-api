using System.ComponentModel.DataAnnotations;

namespace adstaskhub_api.Application.DTOs
{
    public class UserCreateDTO : UserDTOBase
    {
        [Required(ErrorMessage = "O campo 'password' é obrigatório.")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres.")]
        public virtual string Password { get; set; }
    }
}
