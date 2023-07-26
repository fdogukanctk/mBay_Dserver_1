using mBay_Client.Service.IService;
using mBay_Model;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace mBay_Client.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        private string BaseServerUrl;
        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            BaseServerUrl = _configuration.GetSection("BaseServerUrl").Value;
        }
        public async Task<ProductDTO> Get(int productId)
        {
            var result = await _httpClient.GetAsync($"/api/product/getpro/{productId}");
            var content = await result.Content.ReadAsStringAsync();
            if (result.IsSuccessStatusCode)
            {
                var product = JsonConvert.DeserializeObject<ProductDTO>(content);
                product.ImageUrl = BaseServerUrl + product.ImageUrl;
                return product;

            }
            else
            {
                var errorModel = JsonConvert.DeserializeObject<ErrorResponseDTO>(content);
                throw new Exception(errorModel.ErrorMessage);
            }
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()//listeleme
        {
            var result = await _httpClient.GetAsync("/api/product");
            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(content);
                foreach(var item in products)
                {
                    item.ImageUrl = BaseServerUrl + item.ImageUrl;
                }
                return products;
            }
            return new List<ProductDTO>();
        }

        public async Task<List<ProductDTO>> GetProductByCategoryId(int categoryId)
        {
            var result = await _httpClient.GetAsync($"/api/products/{categoryId}");
            if ( result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ProductDTO>>(content);
                foreach ( var item in products)
                {
                    item.ImageUrl = BaseServerUrl + item.ImageUrl;
                    
                }
                return products;

            }
            return new List<ProductDTO>();
        }
    }
}
