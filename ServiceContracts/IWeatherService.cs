using DI_WeatherApp.Models;

namespace ServiceContracts
{
    public interface IWeatherService
    {
        List<CityWeather> GetCityWeathers();
    }
}
