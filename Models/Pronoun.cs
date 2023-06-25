namespace adstaskhub_api.Models
{
    public class Pronoun
    {
        public virtual long PronounId { get; set; }
        public virtual string Name { get; set; }
        public virtual char Ending { get; set; }
    }
}
