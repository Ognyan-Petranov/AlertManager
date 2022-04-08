using AlertManager.Domain.Models;
using MediatR;

namespace AlertManager.Application.Features.Commands.CreateAlert
{
    public class CreateAlertCommand : IRequest<Unit>
    {
        public CreateAlertCommand(Condition condition)
        {
            Condition = condition;
        }

        public Condition Condition { get; private set; }

        public bool IsValid { get; set; }

        public bool IsOpen { get; set; }
    }
}
