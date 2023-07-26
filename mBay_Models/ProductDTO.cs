

using mBay_DataAccsess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mBay_Model
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen isim giriniz")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama giriniz")]
        public bool ShopFavourites { get; set; }
        public bool CustomerFavourites { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen Kategori Seçiniz")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public ICollection<ProductPriceDTO> ProductPrices { get; set; }
    }
}
