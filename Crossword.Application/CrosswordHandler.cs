using Domain;
using MediatR;

namespace Application
{
    public class CrosswordHandler : IRequestHandler<CrosswordRequest, Game>
    {
        public Task<Game> Handle(CrosswordRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public record CrosswordRequest : IRequest<Game>;
}