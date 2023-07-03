using adstaskhub_api.Domain.Enums;

namespace adstaskhub_api.Application.DTOs
{
    public class UserDTOBase
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual ClassDTO? Class { get; set; }
        public virtual Pronoun Pronoun { get; set; }
    }
}
