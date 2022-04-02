using Domain;

namespace Infra
{
    public class TermRepository : ITermRepository
    {
        public TermRepository(TermContext gameContext)
        {
            _crosswordContext = gameContext;
        }

        private readonly TermContext _crosswordContext;

        public async Task Add(Term term)
        {
            await _crosswordContext.Terms.AddAsync(term);
        }

        public async Task<Term> GetRandom()
        {
            var count = _crosswordContext.Terms.Count();
            var random = Random.Shared.Next(count);

            return await Task.Run(() => _crosswordContext.Terms.ElementAt(random));
        }
    }
}