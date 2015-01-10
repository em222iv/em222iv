using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Domain.Webservices
{
    
    public interface  IGeoNameWebService
    {
        IEnumerable<Location> GetLocations(string location);
    }
}