using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("tblBrand")]
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }
    }
}