using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Domain;
using Weather.Domain.Webservices;
using Weather.ViewModels;

namespace Weather.Controllers
{
    public class LocationController : Controller
    {
        private IWeatherGeoNameService _service;
        private IWeatherForecastService _forecastservice;
        

        public LocationController()
            : this(new WeatherGeoNameService(), new WeatherForecastService())
        {
            // Empty!
        }

        public LocationController(IWeatherGeoNameService service, IWeatherForecastService forecastservice)
        {
            _service = service;
            _forecastservice = forecastservice;
        }

        public ActionResult Index()
        {
            return View();
        }
        // POST: /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "City")] WeatherIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.location = _service.GetLocations(model.City);
                    if (model.location.Count() == 1) 
                    {
                       
                        return RedirectToAction("Weather",model.location.First());
                    }
                }
            }
            catch (Exception ex)
            {
                // Get the innermost exception.
               // TempData["success"] = "Person tillagd.";
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }
                ModelState.AddModelError(String.Empty, ex.Message);
            }
            return View(model);
        }

        public ActionResult Weather(WeatherIndexViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.forecast = _forecastservice.GetForecasts(model.ID, model.City, model.Region);

                
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
            return View("Forecast",model);
        }
    }
}