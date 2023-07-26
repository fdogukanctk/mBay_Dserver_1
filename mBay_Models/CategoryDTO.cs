using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mBay_Model
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen Kategori ismi giriniz!.")]
        public string Name { get; set; }
    }
}
