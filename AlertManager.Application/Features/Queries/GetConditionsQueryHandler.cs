using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.Interfaces;
using MediatR;

namespace AlertManager.Application.Features.Queries
{
    public class GetConditionsQueryHandler : IRequestHandler<GetConditionsQuery, string[]>
    {
        private readonly IFakeApiService _fakeApiService;
        private readonly IMediator _mediator;

        public GetConditionsQueryHandler(IFakeApiService fakeApiService, IMediator mediator)
        {
            _fakeApiService = fakeApiService;
            _mediator = mediator;
        }

        public Task<string[]> Handle(GetConditionsQuery request, CancellationToken cancellationToken)
        {
            var result = _fakeApiService.GetConditions();

            return Task.FromResult(result.ToArray());
        }
    }
}
