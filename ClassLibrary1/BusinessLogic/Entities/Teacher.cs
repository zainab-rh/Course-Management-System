using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Teacher : Person{
        public Teacher() : base(){
            TaughtCourses = new List<TaughtCourse>();
        }

        public Teacher(String personAddress, String id, String personName, int personZipCode, String ssn): base(personAddress, id, personName, personZipCode) {
            TaughtCourses = new List<TaughtCourse>();
            this.Ssn = ssn;
        }

        public bool IsScheduleCompatibleWith(TaughtCourse tc) {
            foreach (TaughtCourse t in TaughtCourses) 
                if (tc.CollidesWith(t)) return false;

            // No collisions
            return true;
        }
    }
}
