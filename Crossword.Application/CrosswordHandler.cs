using Domain;
using MediatR;

namespace Application
{
    public class CrosswordHandler : IRequestHandler<CrosswordRequest, Game?>
    {
        public CrosswordHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        private readonly IMediator _mediator;

        public async Task<Game?> Handle(CrosswordRequest request, CancellationToken cancellationToken)
        {
            var terms = await _mediator.Send(new TermRequest(request.WordsCount), cancellationToken);

            if (terms is null)
                return null;

            return Game.Generate(terms, request.WordsCount * Game.WordsConstant);
        }
    }
    public record CrosswordRequest(int WordsCount) : IRequest<Game?>;
}