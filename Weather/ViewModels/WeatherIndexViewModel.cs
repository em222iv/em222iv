using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Weather.Domain;

namespace Weather.ViewModels
{
    public class WeatherIndexViewModel
    {
        [Required(ErrorMessage="Field empty")]
        public string City { get; set; }
        public string Region { get; set; }
        public int ID { get; set; }
        public int timestamp { get; set; }
        public int count = 0;

        public IEnumerable<Location> location { get; set; }
        public IEnumerable<forecast> forecast { get; set; }    
    }
}