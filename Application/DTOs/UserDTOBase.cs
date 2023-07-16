using adstaskhub_api.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace adstaskhub_api.Application.DTOs
{
    public class UserDTOBase
    {
        public virtual long Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]

        [EmailAddress(ErrorMessage = "O campo 'email' deve ser um endereço de email válido.")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Celular' é obrigatório.")]
        public virtual string Phone { get; set; }

        [Required(ErrorMessage = "O campo 'Turma' é obrigatório.")]
        public virtual ClassDTO? Class { get; set; }

        [Required(ErrorMessage = "O campo 'Pronome' é obrigatório.")]
        public virtual Pronoun Pronoun { get; set; }
    }
}
