using AlertManager.API.Models.Requests;
using AlertManager.Application.Features.Commands.CreateAlert;
using AutoMapper;

namespace AlertManager.API.Automapper
{
    public class RequestToCommandProfiles : Profile
    {
        public RequestToCommandProfiles()
        {
            CreateMap<CreateAlertRequest, CreateAlertCommand>();
        }
    }
}
