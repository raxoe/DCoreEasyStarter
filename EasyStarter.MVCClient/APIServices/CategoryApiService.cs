using EasyStarter.Model.Models;
using EasyStarter.MVCClient.Models;
using Newtonsoft.Json;

namespace EasyStarter.MVCClient.APIServices
{
    public class CategoryApiService: ICategoryApiService
    {
        private readonly HttpClient _httpClient;
        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ApiResponse<HttpContent>> AddCategoryAsync(CategoryModel categoryModel)
        {
            try
            {
                string json = JsonConvert.SerializeObject(categoryModel);   //using Newtonsoft.Json

                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


                var response = await _httpClient.PostAsync("Category", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse<HttpContent> { Success = true, Data = response.Content };
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<HttpContent>
                {
                    Success = false,
                    //Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request", AdditionalDetails = ex.Message }
                    Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request" }
                };
            }

            return new ApiResponse<HttpContent> { Success = true, Data = null };
        }
        public async Task<ApiResponse<CategoryModel>> DeleteCategoryAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteFromJsonAsync<CategoryModel>("Category");


                return new ApiResponse<CategoryModel> { Success = true, Data = response };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<CategoryModel>
                {
                    Success = false,
                    //Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request", AdditionalDetails = ex.Message }
                    Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request" }
                };
            }

            return new ApiResponse<CategoryModel> { Success = true, Data = new CategoryModel() { } };
        }

        public async Task<ApiResponse<List<CategoryViewModel>>> GetCategoryAsync()
        {
            try
            {
                var foo =await _httpClient.GetAsync("/Category/GetCategory");
                var response = await _httpClient.GetFromJsonAsync<List<CategoryViewModel>>("Category");


                return new ApiResponse<List<CategoryViewModel>> { Success = true, Data = response };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<CategoryViewModel>>
                {
                    Success = false,
                    //Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request", AdditionalDetails = ex.Message }
                    Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request" }
                };
            }

            return new ApiResponse<List<CategoryViewModel>> { Success = true, Data = new List<CategoryViewModel>() { } };
        }
        public async Task<ApiResponse<CategoryModel>> GetCategoryAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<CategoryModel>("Category/"+id);


                return new ApiResponse<CategoryModel> { Success = true, Data = response };
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<CategoryModel>
                {
                    Success = false,
                    //Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request", AdditionalDetails = ex.Message }
                    Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request" }
                };
            }

            return new ApiResponse<CategoryModel> { Success = true, Data = new CategoryModel() { } };
        }
        public async Task<ApiResponse<CategoryModel>> UpdateCategoryAsync(CategoryModel categoryModel)
        {
            try
            {
                string json = JsonConvert.SerializeObject(categoryModel);   //using Newtonsoft.Json
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync("Category", httpContent);

                if (response.IsSuccessStatusCode)
                {
                    return new ApiResponse<CategoryModel> { Success = true, Data = null };
                }
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<CategoryModel>
                {
                    Success = false,
                    //Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request", AdditionalDetails = ex.Message }
                    Error = new ApiError { ErrorCode = 400, ErrorMessage = "Bad Request" }
                };
            }

            return new ApiResponse<CategoryModel> { Success = true, Data = new CategoryModel() { } };
        }
    }
}