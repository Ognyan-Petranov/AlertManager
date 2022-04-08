using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AlertManager.Application.Interfaces;
using AlertManager.Domain.Models;
using AlertManager.Persistance.EF;
using MediatR;

namespace AlertManager.Application.Features.Commands.CreateCondition
{
    public class CreateConditionCommandHandler : IRequestHandler<CreateConditionCommand>
    {
        private readonly IFakeApiService _fakeApiService;
        private readonly AlertManagerContext _alertManagerContext;

        public CreateConditionCommandHandler(IFakeApiService fakeApiService, AlertManagerContext alertManagerContext)
        {
            _fakeApiService = fakeApiService;
            _alertManagerContext = alertManagerContext;
        }

        public async Task<Unit> Handle(CreateConditionCommand request, CancellationToken cancellationToken)
        {
            var response = await Task.FromResult(_fakeApiService.GetConditions());

            var data = response.ToArray();

            var result = new List<Condition>();
            foreach (var expression in data)
            {
                var condition = new Condition(expression);
                result.Add(condition);
            }

            await _alertManagerContext.AddRangeAsync(result);
            _alertManagerContext.SaveChanges();

            return Unit.Value;
        }
    }
}
