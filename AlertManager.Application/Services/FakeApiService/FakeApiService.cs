using System.Collections.Generic;
using AlertManager.Application.Interfaces;

namespace AlertManager.Application.Services.FakeApiService
{
    public class FakeApiService : IFakeApiService
    {
        public ICollection<string> GetConditions()
        {
            var result = new List<string>();
            result.Add("(5+6-(1+15))");
            result.Add("12-[7+6-(12+5)-4]");
            result.Add("))");

            return result;
        }
    }
}
