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
    }
}
