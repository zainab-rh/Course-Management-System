using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestAca.Entities;


namespace GestAca.Services
{
    public interface IGestAcaService
    {
        void RemoveAllData();
        void Commit();

        // Necesario para la inicialización de la BD
        void DBInitialization();
        void AddTeacher(Teacher teacher);
        void AddClassroom(Classroom classroom);
        void AddCourse(Course course);
        void AddTaughtCourse(TaughtCourse tcourse);
        //
        // A partir de aquí los necesarios para los CU solicitados
        //

        // Caso 1: Hector
        List<Teacher> ListTeachersOfTaughtCourse(int taughtCourseId);
        void AssignTeacherToTaughtCourse(int chosenCourse, string selectedTeacher);

        // Caso 2: Rubén
        List<string> ListTaughtCourses();
        TaughtCourse GetTaughtCourseWithId(int id);
        List<string> ListClassroomsOfTaughtCourse(int taughtCourseId);
        void AssignClassroomToTaughtCourse(int chosenCourse, string selectedClassroom);

        // Caso 3: Gabriel
        void AddEnrollment(DateTime enrollmentDate, bool uniquePaymentTaughtCourse, Student s, TaughtCourse tc);
        void AddStudent(String dni, String student, String address, int zipCode, String iban);

        // Caso 4: Zainab
        List<(string StudentName, string PaymentType)> ListStudentsOfTaughtCourse(int taughtCourseId);

        Student GetStudentById(string studentId);
        TaughtCourse GetTaughtCourseById(int courseId);
        bool IsStudentEnrolledInCourse(string studentId, int courseId);
        int GetEnrollmentCount(int courseId);
        DateTime GetTaughtCourseStartDate(int taughtCourseid);

        List<(int id, string name, string desc)> GetTaughtCoursesData();

        Classroom GetClassroomForCourse(int taughtCourseId);
    }
}