using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.Interfaces;
using MediatR;
using Newtonsoft.Json;

namespace AlertManager.Application.Features.Queries
{
    public class GetConditionsQueryHandler : IRequestHandler<GetConditionsQuery, string[]>
    {
        private readonly IFakeApiService _fakeApiService;
        private readonly HttpClient _httpClient;

        public GetConditionsQueryHandler(IFakeApiService fakeApiService, HttpClient httpClient)
        {
            _fakeApiService = fakeApiService;
            _httpClient = httpClient;
        }

        public async Task<string[]> Handle(GetConditionsQuery request, CancellationToken cancellationToken)
        {
            var result = _fakeApiService.GetConditions().ToArray();

            var json = JsonConvert.SerializeObject(result);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("https://localhost:5001/api/alerts/validate", data);

            return result;
        }
    }
}
