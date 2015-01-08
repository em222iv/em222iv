using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather.Domain.Repositories
{
    public interface IWeatherRepository : IDisposable
    {

        IEnumerable<Location> FindLocations(string locationName);
        void AddLocation(Location location);
        void RemoveLocation(Location location);
        void Save();
    }
}
