using DI_WeatherApp.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace DI_WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherService _weatherService;
        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }
        [Route("/")]
        public IActionResult Index()
        {

            return View(_weatherService.GetCityWeathers());
        }


        [Route("weather/{cityCode?}")]
        public IActionResult City(string? cityCode)
        {
            //if cityCode is not supplied in the route parameter
            if (string.IsNullOrEmpty(cityCode))
            {
                //send null as model object to "Views/Weather/Index" view
                return View();
            }

            //invoke service method (get matching city object based on the city code)
            CityWeather? city = _weatherService.GetCityWeathers().Find(item => item.CityUniqueCode == cityCode);

            //send matching city object to "Views/Weather/Index" view
            return View(city);
        }
    }
}
    }
}
