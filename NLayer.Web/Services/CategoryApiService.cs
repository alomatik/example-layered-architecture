using NLayer.Core.DTOs;
using NLayer.Core.Entities;

namespace NLayer.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<Category>> GetAllCategory()
        {
            var response = await _httpClient.GetFromJsonAsync<List<Category>>("categories");
            return response;
        }

    }








}
