using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyEntity
{
    public class Product
    {
        public int ProductId { get; set; }
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string ProductName { get; set; }
        
        //TODO V1 for this one to one relationship
        //public int ProductOrderId { get; set; }

        //TODO V2 normalize this out to a many to many for reuse.
        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
