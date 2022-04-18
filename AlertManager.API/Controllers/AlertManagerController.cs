using System.Threading.Tasks;
using AlertManager.API.Models.Requests;
using AlertManager.Application.Features.Commands.CreateAlert;
using AlertManager.Application.Features.Commands.CreateCondition;
using AlertManager.Application.Features.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AlertManager.API.Controllers
{
    [Route("api/alerts")]
    [ApiController]
    public class AlertManagerController : BaseController
    {
        [HttpGet]
        [Route("get")]
        public async Task<ActionResult<string>> GetConditions()
        {
            var query = new GetConditionsQuery();
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult> ValidateAlerts([FromBody] CreateAlertRequest request)
        {
            var command = Mapper.Map<CreateAlertCommand>(request);
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateConditions()
        {
            var command = new CreateConditionCommand();
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
