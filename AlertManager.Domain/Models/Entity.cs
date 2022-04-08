using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AlertManager.Domain.Models
{
    public abstract class Entity
    {
        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
            CreatedOn = DateTime.UtcNow;
        }

        [Key]
        public string Id { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }
    }
}
