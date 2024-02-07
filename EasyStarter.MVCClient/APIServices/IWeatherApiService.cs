using EasyStarter.MVCClient.Models;

namespace EasyStarter.MVCClient.APIServices
{
    public interface IWeatherApiService
    {
        Task<ApiResponse<List<WeatherForecast>>> GetWeatherAsync();
    }
}