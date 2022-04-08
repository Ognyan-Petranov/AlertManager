using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlertManager.Application.Interfaces;
using MediatR;

namespace AlertManager.Application.Services.DomainEventsService
{
    public abstract class DomainEventsService : IDomainEventsService
    {
        private readonly IMediator _mediator;
        private readonly HashSet<INotification> _invokedEvents;

        protected DomainEventsService(IMediator mediator)
        {
            _invokedEvents = new HashSet<INotification>();
            _mediator = mediator;
        }

        public async Task PublishAsync(DateTime publishTime, Action onPublish = null)
        {
            onPublish?.Invoke();

            var uninvokedDomainEvents = GetEntities()
                .Where(x => x.DomainEvents != null)
                .SelectMany(x => x.DomainEvents)
                .Where(x => !_invokedEvents.Contains(x))
                .ToArray();

            if (!uninvokedDomainEvents.Any())
            {
                return;
            }

            await OnPublish(publishTime);

            foreach (var domainEvent in uninvokedDomainEvents)
            {
                await _mediator.Publish(domainEvent);
                _invokedEvents.Add(domainEvent);
            }

            await PublishAsync(publishTime, onPublish);
        }

        protected abstract IEnumerable<IDomainEventsContainable> GetEntities();

        protected virtual Task OnPublish(DateTime publishTime)
        {
            return Task.CompletedTask;
        }
    }
}
