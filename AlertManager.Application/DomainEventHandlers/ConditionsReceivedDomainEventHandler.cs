using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.Features.Commands.CreateAlert;
using AlertManager.Domain.DomainEvents;
using MediatR;

namespace AlertManager.Application.DomainEventHandlers
{
    public class ConditionsReceivedDomainEventHandler : INotificationHandler<ConditionsReceivedDomainEvent>
    {
        private readonly HttpClient _httpClient;
        private readonly IMediator _mediator;

        public ConditionsReceivedDomainEventHandler(HttpClient httpClient, IMediator mediator)
        {
            _httpClient = httpClient;
            _mediator = mediator;
        }

        public async Task Handle(ConditionsReceivedDomainEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Implement http call to the controller
            //var json = JsonConvert.SerializeObject(notification);
            //var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            // var response = await _httpClient.PostAsync("http://localhost:57017/api/alerts/validate", data);

            var command = new CreateAlertCommand(notification.Conditions);
            await _mediator.Send(command);
        }
    }
}
