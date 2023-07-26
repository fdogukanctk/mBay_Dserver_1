using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mBay_Model
{
    public class ProductPriceDTO
    {
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Fiyat 1'den büyük olmalıdır.")]
        public double Price { get; set; }

    }
}
