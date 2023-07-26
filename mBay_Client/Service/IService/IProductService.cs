using mBay_Model;

namespace mBay_Client.Service.IService
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> Get(int productId);
        public Task<List<ProductDTO>> GetProductByCategoryId(int categoryId);
    }
}
