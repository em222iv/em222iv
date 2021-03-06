﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Weather.Domain.Webservices
{
    public class GeoNameWebService : IGeoNameWebService
    {
        public IEnumerable<Location> GetLocations(string location)
        {
            var rawJson = string.Empty;
            //Använder mig av Tobias Holst konto th222fa eftersom mitt Jh222vp inte fungerar.
            var url = String.Format("http://api.geonames.org/search?name={0}&maxRows=10&style=full&featureClass=P&country=SE&type=json&username=th222fa", location);

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            using (var response = request.GetResponse())
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                rawJson = reader.ReadToEnd();
            }

            return JObject.Parse(rawJson)["geonames"].Select(token => new Location(token));
        }
    }
}