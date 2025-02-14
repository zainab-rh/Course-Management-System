using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Student:Person {
        public String IBAN { get; set;}
        public virtual ICollection<Enrollment> Enrollments { get; set;  }
    }
}
