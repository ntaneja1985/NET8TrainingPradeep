using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductViewModel
    {
        [DisplayName("Product Id ")]
        public int? ProductId { get; set; }
        
        [DisplayName("Product Code")]
        public string? ProductCode { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        [DisplayName("Product Price")]
        public decimal? Price { get; set; }
        //public Address Address { get; set; }
        //public ShortDescription shortDescription { get; set; }
    }
}
