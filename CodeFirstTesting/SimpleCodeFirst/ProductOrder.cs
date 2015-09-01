using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public Person Person { get; set; }
        [ForeignKey("Hello")]
        public List<Product> Products { get; set; }
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string ProductOrderName { get; set; }
    }
}