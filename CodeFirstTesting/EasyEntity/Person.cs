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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PersonId { get; set; }

        [Column(TypeName = "varchar"), Required, MaxLength(32)
            //TODO V5: Add Indexes ,Index("IX_Person_FirstName_LastName", 1, IsUnique = tr)
            ]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar"), Required, MaxLength(32)
            //TODO V5: Add Indexes, Index("IX_Person_FirstName_LastName", 2, IsUnique = true)
            ]
        public string LastName { get; set; }

        [Column(TypeName = "varchar")]
        public string OverlyLongDescriptionField { get; set; }

        //TODO V2: let's remove this field
        [Column(TypeName = "bit")]
        public bool PointlessFlag { get; set; }
    }
}
