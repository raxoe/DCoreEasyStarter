using EasyStarter.MVCClient.Models;
using System.Net.Http;

namespace EasyStarter.MVCClient.APIServices
{
    public class WeatherApiService : IWeatherApiService
    {
        private readonly HttpClient _httpClient;
        public WeatherApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<List<WeatherForecast>>> GetWeatherAsync()
        {
            try
            {
                // API call logic
                ////var response = await _httpClient.GetFromJsonAsync<WeatherForecast>("https://localhost:44320/WeatherForecast");
                string baseAddr = "https://localhost:44320";
                var response = await _httpClient.GetFromJsonAsync<List<WeatherForecast>>("/WeatherForecast");

                
                return new ApiResponse<List<WeatherForecast>> { Success = true, Data = response };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<WeatherForecast>>
                {
                    Success = false,
                    //Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request", AdditionalDetails = ex.Message }
                    Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request" }
                };
            }

            return new ApiResponse<List<WeatherForecast>> { Success = true, Data = new List<WeatherForecast>() { } };

        }
    }
}
