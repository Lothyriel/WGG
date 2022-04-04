using Domain;
using MediatR;
using Newtonsoft.Json;

namespace Application
{
    public class TermHandler : IRequestHandler<TermRequest, List<Term>?>
    {
        private const string TermsEndpoint = "http://term.webapi/randomTerm?count={0}";
        private static readonly HttpClient HttpClient = new();
        public async Task<List<Term>?> Handle(TermRequest request, CancellationToken cancellationToken)
        {
            var responseMessage = await HttpClient.GetAsync(string.Format(TermsEndpoint, request.TermsCount), cancellationToken);

            var message = await responseMessage.Content.ReadAsStringAsync(cancellationToken);

            return JsonConvert.DeserializeObject<List<Term>>(message);
        }
    }
    public record TermRequest(int TermsCount) : IRequest<List<Term>?>;
}