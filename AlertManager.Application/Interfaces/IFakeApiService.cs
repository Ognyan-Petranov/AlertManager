using System.Collections.Generic;

namespace AlertManager.Application.Interfaces
{
    public interface IFakeApiService
    {
        ICollection<string> GetConditions();
    }
}
