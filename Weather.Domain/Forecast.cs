using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Weather.Domain
{
    [MetadataType(typeof(Forecast_Metadata))]
    public partial class forecast
    {
        public class Forecast_Metadata
        {
            public int ID { get; set; }
            public int temperature { get; set; }
            public int symbolID { get; set; }
            public System.DateTime timestamp { get; set; }
            public int period { get; set; }
        }
    }
}