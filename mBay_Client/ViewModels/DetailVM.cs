using mBay_Model;
using System.ComponentModel.DataAnnotations;

namespace mBay_Client.ViewModels
{
    public class DetailVM
    {
        public DetailVM()
        {
            ProductPrice = new();
            Count = 1;
        }
        [Range(1,int.MaxValue,ErrorMessage ="0'dan büyük bir değer giriniz")]
        public int Count { get; set; }
        [Required]
        public int SelectedProductPriceId { get; set; }
        public ProductPriceDTO ProductPrice { get; set; }
    }
}
