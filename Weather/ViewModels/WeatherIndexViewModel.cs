using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Domain;

namespace Weather.ViewModels
{
    public class WeatherIndexViewModel
    {
        public string name { get; set; }

        public IEnumerable<Location> location { get; set; }
    }
}