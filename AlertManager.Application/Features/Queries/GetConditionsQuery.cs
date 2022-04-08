using System.Collections.Generic;
using AlertManager.Domain.Models;
using MediatR;

namespace AlertManager.Application.Features.Queries
{
    public class GetConditionsQuery : IRequest<IEnumerable<Condition>>
    {
    }
}
