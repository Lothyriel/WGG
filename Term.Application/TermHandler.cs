using Domain;
using Infra;
using MediatR;

namespace Application
{
    public class TermHandler : IRequestHandler<TermRequest, List<Term>?>
    {
        public TermHandler(ITermRepository repository)
        {
            _repository = repository;
        }

        private readonly ITermRepository _repository;

        public async Task<List<Term>?> Handle(TermRequest request, CancellationToken cancellationToken)
        {
            if(request.TermsCount < 1)
                return null;

            return await _repository.GetRandom(request.TermsCount);
        }
    }
    public record TermRequest(int TermsCount) : IRequest<List<Term>?>;
}