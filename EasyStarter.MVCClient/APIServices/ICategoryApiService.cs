using EasyStarter.Model.Models;
using EasyStarter.MVCClient.Models;

namespace EasyStarter.MVCClient.APIServices
{
    public interface ICategoryApiService
    {
        Task<ApiResponse<List<CategoryModel>>> GetCategoryAsync();
        Task<ApiResponse<CategoryModel>> GetCategoryAsync(int id);
        Task<ApiResponse<HttpContent>> AddCategoryAsync(CategoryModel categoryModel);
        Task<ApiResponse<CategoryModel>> UpdateCategoryAsync(CategoryModel categoryModel);
        Task<ApiResponse<CategoryModel>> DeleteCategoryAsync(int id);
    }
}
