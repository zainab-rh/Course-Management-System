using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Teacher: Person {
        public String Ssn { get; set; }
        public virtual ICollection<TaughtCourse> TaughtCourses { get; set; }
    }
}
