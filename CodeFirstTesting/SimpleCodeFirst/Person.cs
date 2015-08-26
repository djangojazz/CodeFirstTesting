using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCodeFirst
{
    [Table("Person")]
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
	    public string LastName { get; set; }
    }
}
