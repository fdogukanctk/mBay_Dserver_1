using AutoMapper;
using mBay_Business.Repository.IRepository;
using mBay_DataAccsess;
using mBay_DataAccsess.Data;
using mBay_Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mBay_Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public CategoryRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;

        }
        public async Task<CategoryDTO> Create(CategoryDTO objDTO)
        {
            var obj = _mapper.Map<CategoryDTO, Category>(objDTO);

            var addedObj = _db.Categories.Add(obj);
            await _db.SaveChangesAsync();// asenkron çalışıyoruz çünkü birden fazla yerde process gerçekleştirilebilir.
            return _mapper.Map<Category, CategoryDTO>(addedObj.Entity);
        }

        public async Task<int> Delete(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                _db.Categories.Remove(obj);
                await _db.SaveChangesAsync();

            }
            return 0;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAll() //foreach döngüsü gibi 
        {
            return _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryDTO>>(_db.Categories);
        }

        public async Task<CategoryDTO> GetById(int id)
        {
            var obj = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (obj != null)
            {
                return _mapper.Map<Category, CategoryDTO>(obj);
            }
            return new CategoryDTO();
        }

        public async Task<CategoryDTO> Update(CategoryDTO objDTO)
        {
            var objFromDb = await _db.Categories.FirstOrDefaultAsync(x => x.Id == objDTO.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = objDTO.Name;
                _db.Categories.Update(objFromDb);
                await _db.SaveChangesAsync();
                return _mapper.Map<Category, CategoryDTO>(objFromDb);
            }
            return objDTO;
        }
    }
}
