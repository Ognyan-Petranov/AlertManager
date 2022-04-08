using AlertManager.Domain.DomainEvents;

namespace AlertManager.Domain.Models
{
    public class Condition : Entity
    {
        public Condition(string expression)
            : base()
        {
            Expression = expression;
            AddDomainEvent(new ConditionsReceivedDomainEvent(this));
        }
        public string Expression { get; set; }
    }
}
