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
    [Table("ProductOrder")]
    public class ProductOrder
    {
        [Key]
        public int ProductOrderId { get; set; }
        public int FK_Person_ProductOrderId { get; set; }
        [ForeignKey("Hello")]
        public Person Person { get; set; }
        
        public List<Product> Products { get; set; }
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string ProductOrderName { get; set; }
    }
}