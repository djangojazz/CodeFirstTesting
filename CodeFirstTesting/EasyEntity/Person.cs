using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyEntity
{
    public class Person
    {
        public int PersonId { get; set; }
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar")]
        [Required]
        [MaxLength(32)]
        public string LastName { get; set; }

        [Column(TypeName = "varchar")]
        public string OverlyLongDescriptionField { get; set; }

        //TODO V4: let's remove this field
        [Column(TypeName = "bit")]
        public bool PointlessFlag { get; set; }
    }
}
