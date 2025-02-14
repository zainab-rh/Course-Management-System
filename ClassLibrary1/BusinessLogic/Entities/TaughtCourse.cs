using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestAca.Entities {
    public partial class TaughtCourse {
        public TaughtCourse() {
            Teachers = new List<Teacher>();
            Enrollments = new List<Enrollment>();
        }

        public TaughtCourse(DateTime endDate, int id, int quotas, int sessionDuration, DateTime startDateTime, String teachingDay, int totalPrice, Course course):this() {
            this.EndDate = endDate;
            this.Id = id;
            this.Quotas = quotas;
            this.SessionDuration = sessionDuration;
            this.StartDateTime = startDateTime;
            this.TeachingDay = teachingDay; //
            this.TotalPrice = totalPrice;
            this.Course = course;
        }

        public bool AssignTeacher(Teacher t) {
            Teachers.Add(t);
            return true;
        }

        public bool CollidesWith(TaughtCourse other) {
            if (TeachingDay != other.TeachingDay) return true;
            if (EndDate < other.StartDateTime) return true;
            if (StartDateTime > other.EndDate) return true;

            int ts, te, os, oe;

            ts = StartDateTime.Hour * 60 + StartDateTime.Minute;
            te = ts + SessionDuration;
            os = other.StartDateTime.Hour * 60 + other.StartDateTime.Minute;
            oe = os + other.SessionDuration;

            if (te < os || oe < ts) return true;
            return false;
        }

    }
}
