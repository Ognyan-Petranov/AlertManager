using AlertManager.Domain.Models;
using MediatR;

namespace AlertManager.Domain.DomainEvents
{
    public class ConditionsReceivedDomainEvent : INotification
    {
        public ConditionsReceivedDomainEvent(Condition conditions)
        {
            Conditions = conditions;
        }
        public Condition Conditions { get; set; }
    }
}
