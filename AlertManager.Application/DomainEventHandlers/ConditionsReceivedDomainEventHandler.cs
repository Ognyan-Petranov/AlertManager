using AlertManager.Application.DomainEvents;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlertManager.Application.DomainEventHandlers
{
    public class ConditionsReceivedDomainEventHandler : INotificationHandler<ConditionsReceivedDomainEvent>
    {
        private readonly HttpClient _httpClient;

        public ConditionsReceivedDomainEventHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Handle(ConditionsReceivedDomainEvent notification, CancellationToken cancellationToken)
        {
            var json = JsonConvert.SerializeObject(notification.Conditions);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync("https://localhost:5001/api/alerts/validate", data);
        }
    }
}
