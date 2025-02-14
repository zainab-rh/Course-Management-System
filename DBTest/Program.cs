using System;
using System.Data.Entity.Validation;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GestAca.Entities;
using GestAca.Persistence;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace DBTest {
    class Program {
        static void Main(string[] args) {

            try {
                new Program();
            }
            catch (Exception e) {
                printError(e);
            }
            Console.WriteLine("\nPulse una tecla para salir");
            Console.ReadLine();
        }

        static void printError(Exception e) {
            while (e != null) {
                if (e is DbEntityValidationException) {
                    DbEntityValidationException dbe = (DbEntityValidationException)e;

                    foreach (var eve in dbe.EntityValidationErrors) {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors) {
                            Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                                ve.PropertyName,
                                eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                ve.ErrorMessage);
                        }
                    }
                }
                else {
                    Console.WriteLine("ERROR: " + e.Message);
                }
                e = e.InnerException;
            }
        }
        private String GenerateRandomDni(Random random) {
            char[] DniLetters = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };
            int dniNumber = random.Next(10000000, 99999999);
            char dniLetter = DniLetters[dniNumber % 23];
            return $"{dniNumber}{dniLetter}";
        }

        Program() {
            IDAL dal = new EntityFrameworkDAL(new GestAcaDbContext());

            CreateSampleDB(dal);
            PrintSampleDB(dal);
        }


        private void CreateSampleDB(IDAL dal) {
            dal.RemoveAllData();

            Console.WriteLine("CREANDO LOS DATOS Y ALMACENANDOLOS EN LA BD");
            Console.WriteLine("===========================================");

            Console.WriteLine("\n// CREACIÓN DE CURSOS");
            //public Course(string descr, string name)
            Course aCourse1 = new Course("Curso Introductorio Ingenieria Software", "Software Engineering");
            dal.Insert<Course>(aCourse1);
            dal.Commit();
            Course aCourse2 = new Course("Curso Introductorio de Estructuras de datos", "Data Structures");
            dal.Insert<Course>(aCourse2);
            dal.Commit();
            Course aCourse3 = new Course("Curso de Bases de Datos", "Databases");
            dal.Insert<Course>(aCourse3);
            dal.Commit();
            Course aCourse4 = new Course("Curso de Redes de Computadoras", "Computer Networks");
            dal.Insert<Course>(aCourse4);
            dal.Commit();
            Course aCourse5 = new Course("Introducción a la Inteligencia Artificial", "Machine Learning");
            dal.Insert<Course>(aCourse5);
            dal.Commit();

            Console.WriteLine("\n// CREACIÓN DE PROFESORES");
            //Create teachers
            Random r = new Random();
            Teacher aTeacher1 = new Teacher("Calle Valencia 1", GenerateRandomDni(r), "Javier Jaen", 46022, "SSN001");
            Teacher aTeacher2 = new Teacher("Calle Alicante 2", GenerateRandomDni(r), "Jaen Javier", 46023, "SSN002");
            Teacher aTeacher3 = new Teacher("Calle Madrid 6", GenerateRandomDni(r), "Eva Muñoz", 46006, "SSN003");
            dal.Insert(aTeacher1);
            dal.Insert(aTeacher2);
            dal.Insert(aTeacher3);
            dal.Commit();


            Console.WriteLine("\n// CREACIÓN DE TAUGHT COURSES");
            //Create taught courses
            TaughtCourse aTaughtCourse1 = new TaughtCourse(
                DateTime.Parse("2025-12-30"),
                1,
                30,
                120,
                DateTime.Parse("2024-12-31"),
                "Monday",
                1000,
                aCourse1
            );

            TaughtCourse aTaughtCourse2 = new TaughtCourse(
                DateTime.Parse("2024-12-31"),
                2,
                30,
                120,
                DateTime.Parse("2024-01-01"),
                "Wednesday",
                1200,
                aCourse2
            );

            TaughtCourse aTaughtCourse3 = new TaughtCourse(
            DateTime.Parse("2025-06-30"),  // Fecha de fin
            3,                             // Número de sesiones
            25,                            // Capacidad
            90,                            // Duración de cada sesión (minutos)
            DateTime.Parse("2025-03-01"),  // Fecha de inicio
            "Friday",                      // Día de la semana
            1300,                          // Hora de inicio
            aCourse3
);

            // Para aCourse4 - "Curso de Redes de Computadoras"
            TaughtCourse aTaughtCourse4 = new TaughtCourse(
                DateTime.Parse("2025-09-15"),  // Fecha de fin
                4,                             // Número de sesiones
                30,                            // Capacidad
                120,                           // Duración de cada sesión (minutos)
                DateTime.Parse("2025-07-01"),  // Fecha de inicio
                "Tuesday",                     // Día de la semana
                1400,                          // Hora de inicio
                aCourse4
            );

            // Para aCourse5 - "Introducción a la Inteligencia Artificial"
            TaughtCourse aTaughtCourse5 = new TaughtCourse(
                DateTime.Parse("2025-12-20"),  // Fecha de fin
                5,                             // Número de sesiones
                20,                            // Capacidad
                150,                           // Duración de cada sesión (minutos)
                DateTime.Parse("2025-10-01"),  // Fecha de inicio
                "Thursday",                    // Día de la semana
                1600,                          // Hora de inicio
                aCourse5
            );


            // Associate teachers with taught courses
            aTaughtCourse1.Teachers.Add(aTeacher1);
            aTaughtCourse2.Teachers.Add(aTeacher2);
            aTaughtCourse3.Teachers.Add(aTeacher1);
            aTaughtCourse4.Teachers.Add(aTeacher3);
            aTaughtCourse5.Teachers.Add(aTeacher3);

            dal.Insert(aTaughtCourse1);
            dal.Insert(aTaughtCourse2);
            dal.Insert(aTaughtCourse3);
            dal.Insert(aTaughtCourse4);
            dal.Insert(aTaughtCourse5);
            dal.Commit();


            Console.WriteLine("\n// CREACIÓN DE ESTUDIANTES Y MATRÍCULAS");
            //Create 10 students and enroll them in aTaughtCourse1
            Random random = new Random();
            for (int i = 1; i <= 20; i++)
            {
                Student student = new Student(
                    $"Student Address {i}",
                    GenerateRandomDni(random),
                    $"Student {i}",
                    46021,
                    $"IBAN00{i}"
                );
                dal.Insert(student);

                Enrollment enrollment = new Enrollment(
                    DateTime.Now,
                    true,
                    student,
                    aTaughtCourse1
                );

                //Insert the abscenses in the last enrollment
                if (i == 10) {
                    //Create abscenses
                    Absence a1 = new Absence(DateTime.Parse("2024-09-15"));
                    Absence a2 = new Absence(DateTime.Parse("2024-10-20"));
                    enrollment.Absences.Add(a1);
                    enrollment.Absences.Add(a2);
                    dal.Insert(a1);
                    dal.Insert(a2);
                }
                dal.Insert(enrollment);
            }
            dal.Commit();

            Console.WriteLine("\n// CREACIÓN DE AULAS");
            //Create classrooms
            Classroom c1 = new Classroom(30, "Aula 1");
            Classroom c2 = new Classroom(30, "Aula 2");

            // Associate classrooms with taught courses
            aTaughtCourse1.Classroom = c1;
            aTaughtCourse2.Classroom = c2;

            dal.Insert(c1);
            dal.Insert(c2);
            dal.Commit();
        }


        private void PrintSampleDB(IDAL dal) {
            Console.WriteLine("\n\nMOSTRANDO LOS DATOS DE LA BD");
            Console.WriteLine("============================\n");

            Console.WriteLine("\nCursos creados:");
            foreach (Course c in dal.GetAll<Course>())
                Console.WriteLine("   Name: " + c.Name + " Description: " + c.Description);

            // Show the rest of the database
            Console.WriteLine("\nProfesores creados:");
            foreach (Teacher t in dal.GetAll<Teacher>())
                Console.WriteLine("   ID: " + t.Id + " Name: " + t.Name);

            Console.WriteLine("\nImparticiones de cursos creados:");
            foreach (Course c in dal.GetAll<Course>()) {
                Console.WriteLine("   Name: " + c.Name + " Description: " + c.Description);
                foreach (TaughtCourse tc in c.TaughtCourses)
                    Console.WriteLine("      ID: " + tc.Id + " START: " + tc.StartDateTime + " END: " + tc.EndDate);
            }

            Console.WriteLine("\nInscripciones por curso a impartir:");
            foreach (Course c in dal.GetAll<Course>()) {
                Console.WriteLine("   Name: " + c.Name + " Description: " + c.Description);
                foreach (TaughtCourse tc in c.TaughtCourses) {
                    Console.WriteLine("      ID: " + tc.Id + " START: " + tc.StartDateTime + " END: " + tc.EndDate);
                    foreach (Enrollment en in tc.Enrollments)
                        Console.WriteLine("      ---> Student: " + en.Student.Name + " Enrollment Date: " + en.EnrollmentDate);
                }

            }

            Console.WriteLine("\nAulas creadas y sus asignaciones");
            foreach (Classroom o in dal.GetAll<Classroom>()) {
                Console.WriteLine("   Name: " + o.Name + " Capacity: " + o.MaxCapacity);
                foreach (TaughtCourse tc in o.TaughtCourses)
                    Console.WriteLine("      CourseID: " + tc.Id + " START: " + tc.StartDateTime + " END: " + tc.EndDate + " People: " + tc.Enrollments.Count);
            }

            Console.WriteLine("\nFaltas de asistencia por alumno");
            foreach (Student s in dal.GetAll<Student>()) {
                Console.WriteLine("   Student Name: " + s.Name);
                foreach (Enrollment en in s.Enrollments) {
                    Console.WriteLine("      Enrollment in: " + en.TaughtCourse.Id + " Course name: " + en.TaughtCourse.Course.Name + " Absences: " + en.Absences.Count);
                    foreach (Absence ab in en.Absences)
                        Console.WriteLine("         Date: " + ab.Date);
                }

            }
        }

    }

}