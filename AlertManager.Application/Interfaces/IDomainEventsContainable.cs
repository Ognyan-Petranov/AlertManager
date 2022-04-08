using System.Collections.Generic;
using MediatR;

namespace AlertManager.Application.Interfaces
{
    public interface IDomainEventsContainable
    {
        IReadOnlyCollection<INotification> DomainEvents { get; }

    }
}
