using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient )
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            //var resp = await _httpClient.GetAsync("products");
            var response = await _httpClient.GetFromJsonAsync<ResponseDto<List<ProductDto>>>("products");

            return response.Data;

        }

        public async Task<ProductDto> Save(ProductDto productDto)
        {
            var response = await _httpClient.PostAsJsonAsync("products", productDto);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<ProductDto>();

            return responseBody;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<ProductDto>($"products/{id}");
            return response;
        }
        public async Task Update(ProductDto productDto)
        {
            var response = await _httpClient.PutAsJsonAsync("products", productDto);
        }



    }
}
