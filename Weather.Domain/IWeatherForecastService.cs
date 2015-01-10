using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain
{
    public interface IWeatherForecastService
    {
        IEnumerable<forecast> GetForecasts(int ID, string City, string Region);
    }
}
