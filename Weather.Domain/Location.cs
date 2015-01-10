using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Weather.Domain
{
        [MetadataType(typeof(Location_Metadata))]
        public partial class Location
        {
            public Location(JToken locationToken)
                : this()
            {
                City = locationToken.Value<string>("toponymName");
                Long = locationToken.Value<string>("lng");
                Lat = locationToken.Value<string>("lat");
                Region = locationToken.Value<string>("adminName1");
            }

            public class Location_Metadata
            {
                [Required]
                [Display(Name = "Sök plats")]
                public string City { get; set; }
            }
        }
}