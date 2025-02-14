using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Student : Person {

        public Student() : base() { // if later there is an addition to person constructor
            Enrollments = new List<Enrollment>();
        }

        public Student(String personAddress, String id, String personName, int personZipCode, String iban): base(personAddress, id, personName, personZipCode)
        {
            Enrollments = new List<Enrollment>();
            this.IBAN = iban;
        }
    }
}
