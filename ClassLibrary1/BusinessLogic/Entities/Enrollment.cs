using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Enrollment {
        public Enrollment() 
        {
            Absences = new List<Absence>();
        }
        public Enrollment(DateTime enrollmentDate, bool uniquePayment, Student s, TaughtCourse tc) : this() {
            this.EnrollmentDate = enrollmentDate;
            this.UniquePayment = uniquePayment;
            this.Student = s;
            this.TaughtCourse = tc;
        }
    }
}
