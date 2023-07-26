using mBay_Client.Service.IService;
using mBay_Model;
using Newtonsoft.Json;

namespace mBay_Client.Service
{
    public class CategoryService : ICategoryService
    {
        private HttpClient _httpClient;
        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll()
        {
            var response = await _httpClient.GetAsync("/api/category");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(content);
                return categories;
            }
            return new List<CategoryDTO>();
        }

    }
}
