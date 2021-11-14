using AlertManager.Application.Enums;
using FluentValidation;

namespace AlertManager.Application.Features.Commands.CreateAlert
{
    public class CreateAlertCommandValidator : AbstractValidator<CreateAlertCommand>
    {
        public CreateAlertCommandValidator()
        {
            RuleFor(x => x.Condition)
                .NotEmpty()
                .WithMessage(ValidationErorMessage.InvalidCondition);
        }
    }
}
