using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Webservices
{
    public interface IForecastWebService
    {
        IEnumerable<forecast> GetForecast(string forecast, string region, int id);
    }
}
