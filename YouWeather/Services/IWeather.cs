using System.Threading.Tasks;

namespace YouWeather.Services
{
	public interface IWeather
    {
	    Task<string> GetCurrentForecastByCityName(string CityName);
    }
}
