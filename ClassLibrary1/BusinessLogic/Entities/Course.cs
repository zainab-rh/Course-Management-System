using GestAca.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class Course {
        public Course(){
            TaughtCourses = new List<TaughtCourse>();
        }

        public Course(String descr, String name): this()
        {
            this.Name = name;
            this.Description = descr;
        }

    }
}
