using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    [Table("ProductOrder")]
    public class ProductOrder
    {
        public int ProductOrderId { get; set; }
        public Person Person { get; set; }
        public List<Product> Products { get; set; }
        public string ProductOrderName { get; set; }
    }
}