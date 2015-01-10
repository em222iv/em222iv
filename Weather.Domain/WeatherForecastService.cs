using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Domain.Repositories;
using Weather.Domain.Webservices;

namespace Weather.Domain
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private IForecastRepository _repository;
        private IForecastWebService _webservice;

        public WeatherForecastService()
            : this(new ForecastRepository(), new ForecastWebService())
        {
        }

        public WeatherForecastService(IForecastRepository repository, IForecastWebService webservice)
        {
            _repository = repository;
            _webservice = webservice;
        }
        public IEnumerable<forecast> GetForecasts(int ID, string City, string Region)
        {
            var locationName = City;
            var region = Region;
            var id = ID;
            var count = 0;

            var forecasts = _repository.FindForecasts(id);


            if (forecasts.Count() == 0)
            {
                forecasts = _webservice.GetForecast(locationName, region, id);
                bool exit = true;
                foreach (var item in forecasts)
                {
                    if (exit == true)
                    {
                        if (item.period == 2)
                        {
                            _repository.AddForecasts(item);
                            exit = false;
                            count++;
                        }
                        else if (item.period == 3)
                        {
                            _repository.AddForecasts(item);
                            exit = false;
                            count++;
                        }
                    }
                    else if (item.period == 2)
                    {
                        _repository.AddForecasts(item);
                        count++;
                    }
                    if (count == 5) 
                    {
                        break;
                    }

                }
                _repository.Save();
            }

            var filteredForecasts = _repository.FindForecasts(id);
            return filteredForecasts;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}