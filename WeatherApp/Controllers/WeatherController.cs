using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.BL.Repository;

namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        public WeatherController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            var weathers = _weatherRepository.GetWeather();
            if (weathers != null)
            {
                ViewBag.totalPages = Math.Ceiling((decimal)weathers.Count() / pageSize);
                ViewBag.currentPage = page;
            }
            return View(weathers.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }
    }
}