using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Repositories
{
    public interface IForecastRepository : IDisposable
    {
        IEnumerable<forecast> FindForecasts(int ID);
        void AddForecasts(forecast forecast);
        void RemoveForecasts(int locationId);
        void Save();
    }
}
