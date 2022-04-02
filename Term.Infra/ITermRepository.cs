using Domain;

namespace Infra
{
    public interface ITermRepository
    {
        Task Add(Term term);
        Task<Term> GetRandom();
    }
}