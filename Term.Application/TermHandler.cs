using Domain;
using Infra;
using MediatR;

namespace Application
{
    public class TermHandler : IRequestHandler<TermRequest, Term>
    {
        public TermHandler(ITermRepository repository)
        {
            _repository = repository;
        }

        private readonly ITermRepository _repository;

        public async Task<Term> Handle(TermRequest request, CancellationToken cancellationToken)
        {
            return await _repository.GetRandom();
        }
    }
    public record TermRequest : IRequest<Term>;
}