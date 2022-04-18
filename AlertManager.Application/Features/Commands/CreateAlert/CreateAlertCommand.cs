using MediatR;

namespace AlertManager.Application.Features.Commands.CreateAlert
{
    public class CreateAlertCommand : IRequest<Unit>
    {
        public string Expression { get; set; }

        public bool IsValid { get; set; }

        public bool IsOpen { get; set; }
    }
}
