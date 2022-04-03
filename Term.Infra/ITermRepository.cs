using Domain;

namespace Infra
{
    public interface ITermRepository
    {
        Task Add(Term term);
        Task<Term?> GetByWord(string word);
        Task<Term> GetRandom();
    }
}