using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace YouWeather.Services
{
	public class WeatherService : IWeather
	{
		//key: 2a1a9b7d0e909ad4719c8b4305bd8377;
		//api.openweathermap.org/data/2.5/weather?q=warsaw&APPID=2a1a9b7d0e909ad4719c8b4305bd8377

		private const string BASE_URL = "http://api.openweathermap.org/data/2.5/weather?q=";
		private const string APIKEY = "&APPID=2a1a9b7d0e909ad4719c8b4305bd8377";

		//TODO: Make this secret in json;

		public async Task<string> GetCurrentForecastByCityName(string CityName)
		{
			//TODO: TRY/CATCH
			string _MovieJson;
			//string url = BASE_URL + CityName + APIKEY;
			using (HttpClient hc = new HttpClient())
			{
				//string url = "http://api.openweathermap.org/data/2.5/weather?q=warsaw&APPID=2a1a9b7d0e909ad4719c8b4305bd8377";
				var Moviejson = await hc.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=" + CityName + "&APPID=2a1a9b7d0e909ad4719c8b4305bd8377");
				_MovieJson = Moviejson;
			}
			return _MovieJson;
		}
	}
}
