using Domain;
using Infra;
using MediatR;

namespace Application
{
    public record AddTermRequest : IRequest<Unit>
    {
        public AddTermRequest(Term term)
        {
            Term = term;
        }
        public Term Term { get; }
    }

    public class AddTermHandler : IRequestHandler<AddTermRequest>
    {
        public AddTermHandler(ITermRepository repository)
        {
            _repository = repository;
        }

        private readonly ITermRepository _repository;

        public Task<Unit> Handle(AddTermRequest request, CancellationToken cancellationToken)
        {
            _repository.Add(request.Term);
            return Unit.Task;
        }
    }
}