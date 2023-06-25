namespace adstaskhub_api.Models
{
    public class User
    {
        public virtual long UserId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Phone { get; set; }
        public virtual Class Class { get; set; }
        public virtual Pronoun Pronoun { get; set; }
        public virtual Role Role { get; set; }
    }
}
