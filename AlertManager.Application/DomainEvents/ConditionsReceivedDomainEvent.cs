using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlertManager.Application.DomainEvents
{
    public class ConditionsReceivedDomainEvent : INotification
    {
        public ConditionsReceivedDomainEvent(string[] conditions)
        {
            Conditions = conditions;
        }
        public string[] Conditions { get; set; }
    }
}
