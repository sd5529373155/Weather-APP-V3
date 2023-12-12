using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Weather_APP.Models;

namespace Weather_APP.Services
{
	public static class ApiService
	{
		public static async Task<Root> GetWeather(double latitude, double longitude)
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?lat={0}&lon={1}&units=metric&appid=a25b567eda7ade477c9d75edf2565c6f", latitude, longitude));
			return JsonConvert.DeserializeObject<Root>(response);
        }

		public static async Task<Root> GetWeatherByCity(string city)
		{
			var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync(string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&units=metric&appid=a25b567eda7ade477c9d75edf2565c6f", city));
			return JsonConvert.DeserializeObject<Root>(response);
		}
	}
}