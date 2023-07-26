using mBay_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mBay_Business.Repository.IRepository
{
    public interface IProductRepository
    {
        public Task<ProductDTO> Create(ProductDTO objDTO);
        public Task<ProductDTO> Update(ProductDTO objDTO);
        public Task<int> Delete(int id);
        public Task<ProductDTO> GetById(int id);//detay
        public Task<IEnumerable<ProductDTO>> GetAll();//listeleme
        public Task<List<ProductDTO>> GetProductByCategoryId(int id);
    }
}
