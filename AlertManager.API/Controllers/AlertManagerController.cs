using System.Threading.Tasks;
using AlertManager.Application.Features.Commands.CreateAlert;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AlertManager.API.Controllers
{
    [Route("api/alerts")]
    [ApiController]
    public class AlertManagerController : BaseController
    {
        [HttpPost]
        [Route("validate")]
        public async Task<ActionResult> ValidateAlerts([FromForm] string condition)
        {
            var command = new CreateAlertCommand(condition);
            var result = await Mediator.Send(command);

            return Ok();
        }
    }
}
