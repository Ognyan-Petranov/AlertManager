using MediatR;

namespace AlertManager.Application.Features.Commands.CreateAlert
{
    public class CreateAlertCommand : IRequest<Unit>
    {
        public CreateAlertCommand(string[] condition)
        {
            Condition = condition;
        }

        public string[] Condition { get; private set; }

        public bool IsValid { get; set; }

        public bool IsOpen { get; set; }
    }
}
