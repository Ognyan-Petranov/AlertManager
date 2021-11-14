using MediatR;

namespace AlertManager.Application.Features.Queries
{
    public class GetConditionsQuery : IRequest<string[]>
    {
        public string[] Conditions { get; set; }
    }
}
