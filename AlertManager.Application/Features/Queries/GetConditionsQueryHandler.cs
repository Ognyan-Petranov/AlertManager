using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.DomainEvents;
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

        public async Task<string[]> Handle(GetConditionsQuery request, CancellationToken cancellationToken)
        {
            var conditions = _fakeApiService.GetConditions().ToArray();

            var domainEvent = new ConditionsReceivedDomainEvent(conditions);
            await _mediator.Publish(domainEvent);
            
            return conditions;
        }
    }
}
