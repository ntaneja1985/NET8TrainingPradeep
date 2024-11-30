using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; } //int
        [Column(TypeName ="varchar(200)")]
        public string ProductCode { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; } //nvarchar(MAX) by default
        public decimal Price { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        //Navigation Property
        public Category Category { get; set; }
    }
}
