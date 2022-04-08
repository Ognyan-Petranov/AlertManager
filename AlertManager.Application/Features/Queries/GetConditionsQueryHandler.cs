using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Domain.Models;
using AlertManager.Persistance.EF;
using MediatR;

namespace AlertManager.Application.Features.Queries
{
    public class GetConditionsQueryHandler : IRequestHandler<GetConditionsQuery, IEnumerable<Condition>>
    {
        private readonly AlertManagerContext _alertManagerContext;

        public GetConditionsQueryHandler(AlertManagerContext alertManagerContext)
        {
            _alertManagerContext = alertManagerContext;
        }

        public async Task<IEnumerable<Condition>> Handle(GetConditionsQuery request, CancellationToken cancellationToken)
        {
            var result = _alertManagerContext.Conditions.Select(a => a).ToList();

            return result;
        }
    }
}
