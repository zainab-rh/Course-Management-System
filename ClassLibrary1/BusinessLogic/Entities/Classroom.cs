using GestAca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Classroom {
        public Classroom() 
        {
            TaughtCourses = new List<TaughtCourse>();
        }
        public Classroom(int maxCapacity, String name) : this() { 
            this.MaxCapacity = maxCapacity;
            this.Name = name;
        }

        public bool IsScheduleCompatibleWith(TaughtCourse tc) {
            foreach (TaughtCourse t in TaughtCourses)
                if (tc.CollidesWith(t)) return false;

            return tc.Quotas <= MaxCapacity;
        }


        public bool AssignTaughtCourse(TaughtCourse tc){
            TaughtCourses.Add(tc);
            return true;
        }
    }
}
