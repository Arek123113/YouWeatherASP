using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using YouWeather.Models;
using YouWeather.Services;

namespace YouWeather.Controllers
{
    public class WeatherController : Controller
    {
	    private readonly IWeather _weatherservice;

	    public WeatherController(IWeather weather)
	    {
		    _weatherservice = weather;
	    }

        public IActionResult Index()
        {
            return View();
        }

		[Route("weather/currentweather")]
	    public async Task<IActionResult> CurrentWeather(string query)
	    {
		    string city = query;
		    string json = await _weatherservice.GetCurrentForecastByCityName(city);
		    var weather = JsonConvert.DeserializeObject<RootObject>(json);

		    string icon_src = "http://openweathermap.org/img/w/" + weather.weather[0].icon + ".png";
			double temperature = weather.main.temp - 273.15;
		    double MAX_TEMP = weather.main.temp_max - 273.15;
		    double MIN_TEMP = weather.main.temp_min - 273.15;
			
		    ViewBag.maxtemp = MAX_TEMP;
		    ViewBag.mintemp = MIN_TEMP;
			ViewBag.cityTemp = temperature;
			ViewBag.city = city;
		    ViewBag.IconImage = icon_src;
		    return View(weather);
	    }
    }
}