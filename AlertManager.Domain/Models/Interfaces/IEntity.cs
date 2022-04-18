using System;
using System.Collections.Generic;
using MediatR;

namespace AlertManager.Domain.Models.Interfaces
{
    public interface IEntity
    {
        public string Id { get; }

        public DateTime CreatedOn { get; }

        public List<INotification> DomainEvents { get; }

        public void AddDomainEvent(INotification eventItem);
    }
}
