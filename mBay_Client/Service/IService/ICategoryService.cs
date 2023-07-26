using mBay_Model;

namespace mBay_Client.Service.IService
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAll();
    }
}
