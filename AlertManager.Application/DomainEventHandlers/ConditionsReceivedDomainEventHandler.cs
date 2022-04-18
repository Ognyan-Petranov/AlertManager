using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.Models.Requests;
using AlertManager.Domain.DomainEvents;
using MediatR;
using Newtonsoft.Json;

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
            var request = new CreateAlertRequest(notification.Conditions.Expression);
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("http://localhost:57017/api/alerts/validate", data);

            //var command = new CreateAlertCommand(notification.Conditions);
            //await _mediator.Send(command);
        }
    }
}
