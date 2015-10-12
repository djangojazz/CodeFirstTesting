using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyEntity
{
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public Person Person { get; set; }

        public List<Product> Products { get; set; }
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string ProductOrderName { get; set; }
    }
}
