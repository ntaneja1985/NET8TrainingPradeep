using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using WebApp.Custom;

namespace ViewModels
{
    public class ProductViewModel
    {
        [DisplayName("Product Id ")]
        public int? ProductId { get; set; }

        [DisplayName("Product Code")]
        [Required(ErrorMessage = "Product code is Mandatory")]
        //[CodeValidator(Character = "P", ErrorMessage = "Product code is not starting with P")]
        public string? ProductCode { get; set; }
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "Product name is Mandatory")]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "Product Name is invalid")]
        public string? ProductName { get; set; }
        [DisplayName("Product Price")]
        [Range(1, double.MaxValue)]
        public decimal? Price { get; set; }

        [DisplayName("Category")]
        [Required(ErrorMessage ="Select Category")]
        public int CategoryId {  get; set; }    
        //public Address Address { get; set; }
        //public ShortDescription shortDescription { get; set; }
    }
}
