using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YouWeather.Services
{
    public interface IIPadress
    {
	    Task<string> GetUsersIpAdress();
    }
}
