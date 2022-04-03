using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class TermRepository : ITermRepository
    {
        private readonly TermContext _termContext;

        public TermRepository(TermContext termContext)
        {
            _termContext = termContext;
        }

        public async Task Add(Term term)
        {
            await _termContext.Terms.AddAsync(term);
            await _termContext.SaveChangesAsync();
        }

        public async Task<Term?> GetByWord(string word)
        {
            return await _termContext.Terms.Where(w => w.Word == word).FirstOrDefaultAsync();
        }

        public async Task<Term> GetRandom()
        {
            return await _termContext.Terms.OrderBy(c => Guid.NewGuid()).FirstAsync();
        }
    }
}