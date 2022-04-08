using System;
using System.Threading.Tasks;

namespace AlertManager.Application.Interfaces
{
    public interface IDomainEventsService
    {
        Task PublishAsync(DateTime publishTime, Action onPublish = null);
    }
}
