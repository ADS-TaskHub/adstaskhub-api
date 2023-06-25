using adstaskhub_api.Models;

namespace adstaskhub_api.Interfaces
{
    public interface IPronounRepository
    {
        Pronoun GetById(int pronounId);
        IList<Pronoun> GetAll();
        void Create(Pronoun pronoun);
        void Update(Pronoun pronoun);
        void Delete(Pronoun pronoun);
    }
}
