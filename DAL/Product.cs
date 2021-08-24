using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("tblProduct")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public DateTime DateofPurchase { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        public string ProductImage { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}