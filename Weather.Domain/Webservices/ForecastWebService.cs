using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace Weather.Domain.Webservices
{
    public class ForecastWebService : IForecastWebService
    {
        public IEnumerable<forecast> GetForecast(string forecast, string region, int id)
        {
            var rawJson = string.Empty;

            var url = String.Format("http://www.yr.no/place/Sweden/{0}/{1}/forecast.xml", region, forecast);

            var request = (HttpWebRequest)WebRequest.Create(url);

            XDocument xml = new XDocument();            
            using (var response = request.GetResponse())
            {
                xml = XDocument.Load(response.GetResponseStream());
            }

            var temperature = xml.Descendants("meta").Elements("nextupdate").First().Value;
            var nextUpdate = DateTime.Parse(temperature);


            return (from bi in xml.Descendants("time")
                    select new forecast
                    {
                        symbolID = Convert.ToInt32(bi.Element("symbol").Attributes("number").First().Value),
                        temperature = Convert.ToInt32(bi.Element("temperature").Attributes("value").First().Value),
                        timestamp = nextUpdate,
                        ID = id,
                        period = Convert.ToInt32(bi.Attribute("period").Value)
                       
                    }).ToList();
        }
    }
}