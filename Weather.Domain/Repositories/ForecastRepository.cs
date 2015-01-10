using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Weather.Domain;


namespace Weather.Domain.Repositories
{
    public class ForecastRepository : IForecastRepository
    {
        private WeatherEntities _context = new WeatherEntities();
        
        public IEnumerable<forecast> FindForecasts(int ID)
        {
            return _context.forecasts.Where(f => f.ID == ID).ToList();
        }

        public void AddForecasts(forecast forecast)
        {
            _context.forecasts.Add(forecast);
        }

        public void RemoveForecasts(int locationId)
        {
            forecast forecast = _context.forecasts.Find(locationId);
            _context.forecasts.Remove(forecast);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}