using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Domain.Webservices;
using Weather.ViewModels;

namespace Weather.Controllers
{
    public class LocationController : Controller
    {
        private IGeoNameWebService _service;

        public LocationController()
            : this(new GeoNameWebService())
        {
            // Empty!
        }

        public LocationController(IGeoNameWebService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View();
        }
        // POST: /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ScreenName")] WeatherIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.location = _service.GetLocations(model.name);
                }
            }
            catch (Exception ex)
            {
                // Get the innermost exception.
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View(model);
        }
    }
}