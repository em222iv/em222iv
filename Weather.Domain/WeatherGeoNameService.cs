using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Domain.Repositories;
using Weather.Domain.Webservices;

namespace Weather.Domain
{
    public class WeatherGeoNameService : IWeatherGeoNameService
    {
        private IWeatherRepository _repository;
        private IGeoNameWebService _webservice;

        public WeatherGeoNameService()
            : this(new WeatherRepository(), new GeoNameWebService())
        {
        }
        public WeatherGeoNameService(IWeatherRepository repository, IGeoNameWebService webservice) 
        {
            _repository = repository;
            _webservice = webservice;
        }

        public IEnumerable<Location> GetLocations(string locationName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}