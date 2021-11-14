using System.Threading.Tasks;
using AlertManager.Application.Features.Commands.CreateAlert;
using AlertManager.Application.Features.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public async Task<ActionResult> ValidateAlerts([FromBody] string[] conditions)
        {
            var command = new CreateAlertCommand(conditions);
            var result = await Mediator.Send(command);

            return Ok(result);
        }
    }
}
