using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
       
        [Column(TypeName = "varchar(50)")]
        public string EmailId { get; set; }

        public string FullName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Password { get; set; }
    }
}
