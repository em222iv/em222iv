using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Weather.Domain;

namespace Weather.Domain.Repositories
{
    public class WeatherRepository : IWeatherRepository 
    {
        private WeatherEntities _context = new WeatherEntities();
        public IEnumerable<Location> FindLocations(string locationName)
        {
            return _context.Locations.Where(l => l.City == locationName);
        }

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
        }

        public void RemoveLocation(Location location)
        {
            if (_context.Entry(location).State == EntityState.Detached)
            {
                _context.Locations.Attach(location);
            }
            _context.Locations.Remove(location);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}