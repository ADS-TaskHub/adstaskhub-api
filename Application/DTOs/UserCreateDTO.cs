namespace adstaskhub_api.Application.DTOs
{
    public class UserCreateDTO : UserDTOBase
    {
        public virtual string Password { get; set; }
    }
}
