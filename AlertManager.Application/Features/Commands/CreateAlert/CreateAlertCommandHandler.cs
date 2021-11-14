﻿using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.Interfaces;
using AlertManager.Domain.Models;
using AlertManager.Persistance.EF;
using MediatR;

namespace AlertManager.Application.Features.Commands.CreateAlert
{
    public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, Unit>
    {
        private readonly IValidationService _validationService;
        private readonly AlertManagerContext _alertManagerContext;

        public CreateAlertCommandHandler(IValidationService validationService, AlertManagerContext alertManagerContext)
        {
            _validationService = validationService;
            _alertManagerContext = alertManagerContext;
        }

        public async Task<Unit> Handle(CreateAlertCommand request, CancellationToken cancellationToken)
        {
            var alert = new Alert(request.Condition);
            alert.IsValid = _validationService.Validate(alert.Condition);
            await _alertManagerContext.Alerts.AddAsync(alert);
            await _alertManagerContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
