using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyEntity
{
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        
        //TODO V1 one to one
        //[ForeignKey("ProductOrderId")]
        public ICollection<Product> Products { get; set; }

        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string ProductOrderName { get; set; }

        public int PersonId { get; set; }
    }
}
