using Domain;
using Infra;
using MediatR;

namespace Application
{
    public record AddTermRequest : IRequest<bool>
    {
        public AddTermRequest(Term term)
        {
            Term = term;
        }
        public Term Term { get; }
    }

    public class AddTermHandler : IRequestHandler<AddTermRequest, bool>
    {
        public AddTermHandler(ITermRepository repository)
        {
            _repository = repository;
        }

        private readonly ITermRepository _repository;

        public async Task<bool> Handle(AddTermRequest request, CancellationToken cancellationToken)
        {
            if (await _repository.GetByWord(request.Term.Word) is not null)
                return false;

            await _repository.Add(request.Term);
            return true;
        }
    }
}