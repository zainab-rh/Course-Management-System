using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using GestAca.Entities;
using GestAca.Persistence;


namespace GestAca.Services
{
    public class GestAcaService : IGestAcaService
    {
        private readonly IDAL dal;

        public GestAcaService(IDAL dal)
        {
            this.dal = dal;
        }

        /// <summary>
        /// Borra todos los datos de la BD
        /// </summary>
        public void RemoveAllData()
        {
            dal.RemoveAllData();
        }

        /// <summary>
        /// Salva todos los cambios que haya habido en el contexto de la aplicación desde la última vez que se hizo Commit
        /// </summary>
        public void Commit()
        {
            dal.Commit();
        }

        public void DBInitialization()
        {
            RemoveAllData();

            // Dar de alta unos profesores para poder usarlos luego
            AddTeacher(new Teacher("C/San Cristobal 10", "11111111A", "Prof1", 46022, "SSN11111111A"));
            AddTeacher(new Teacher("Av. La Informatica 20", "22222222B", "Prof2", 46022, "SSN22222222B"));
            AddTeacher(new Teacher("C/Sulfurosa 30", "33333333C", "Prof3", 46022, "SSN33333333B"));

            // Dar de alta unas aulas para poder usarlas luego
            AddClassroom(new Classroom(2, "1P"));
            AddClassroom(new Classroom(10, "1A"));
            AddClassroom(new Classroom(5, "1G"));

            // Dar de alta unos cursos para poder usarlos luego
            Course aCourse1 = new Course("Curso Introductorio Ingenieria Software", "Software Engineering");
            AddCourse(aCourse1);
            Course aCourse2 = new Course("Curso Introductorio de Estructuras de datos", "Data Structures");
            AddCourse(aCourse2);
            AddCourse(new Course("Curso avanzado de Aerodinámica", "Advance aerodynamics"));

            //Curso empezado en 03/25 Válido para prácticas y recuperación. Se podrán apuntar nuevos estudiantes
            DateTime startDateTime = new DateTime(2025, 3, 24, 9, 30, 0);
            DateTime endDate = new DateTime(2025, 5, 19);
            TaughtCourse aTaughtCourse1 = new TaughtCourse(endDate, 1, 3, 120, startDateTime, "Monday", 1500, aCourse1);
            AddTaughtCourse(aTaughtCourse1);

            // Curso empezado en 04/24
            startDateTime = new DateTime(2024, 4, 15, 12, 0, 0);
            endDate = new DateTime(2024, 11, 30);
            TaughtCourse aTaughtCourse2 = new TaughtCourse(endDate, 2, 2, 120, startDateTime, "Wednesday", 1000, aCourse2);
            AddTaughtCourse(aTaughtCourse2);


        }

        /// <summary>
        /// Persiste un profesor
        /// </summary>
        /// <param name="teacher"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddTeacher(Teacher teacher)
        {
            // Restricción: No puede haber dos personas con el mismo Id (dni)
            if (dal.GetById<Teacher>(teacher.Id) == null)
            {
                dal.Insert<Teacher>(teacher);
                dal.Commit();
            }
            else
                throw new ServiceException("There is another person with Id " + teacher.Id);
        }

        /// <summary>
        /// Persiste un aula
        /// </summary>
        /// <param name="Classroom"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddClassroom(Classroom classroom)
        {
            // Restricción: No puede haber dos aulas con el mismo nombre
            if (!dal.GetWhere<Classroom>(x => x.Name == classroom.Name).Any())
            {
                dal.Insert<Classroom>(classroom);
                dal.Commit();
            }
            else
                throw new ServiceException("There is another classroom with Name " + classroom.Name);
        }

        /// <summary>
        /// Salva en la BD un curso
        /// </summary>
        /// <param name="course"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddCourse(Course course)
        {
            // Restricción: No puede haber dos cursos con el mismo Name
            if (!dal.GetWhere<Course>(x => x.Name == course.Name).Any())
            {
                // Sólo se salva si no hay Name
                dal.Insert<Course>(course);
                dal.Commit();
            }
            else
                throw new ServiceException("Course with name " + course.Name + " already exists.");
        }

        /// <summary>
        /// Persiste el curso a impartir
        /// </summary>
        /// <param name="tcourse"></param>
        /// <exception cref="ServiceException"></exception>
        public void AddTaughtCourse(TaughtCourse tcourse)
        {
            // Restricción: No puede haber dos TaughtCourses con el mismo Id
            if (dal.GetById<TaughtCourse>(tcourse.Id) == null)
            {
                dal.Insert<TaughtCourse>(tcourse);
                dal.Commit();
            }
            else
                throw new ServiceException("Taught Course with Id " + tcourse.Id + " already exists.");
        }
        public List<(int id, string name, string desc)> GetTaughtCoursesData()
        {
            var tCourses = dal.GetAll<TaughtCourse>();

            // - TaughtCourse Id
            // - Course Name
            // - Course Description
            var tCourseList = tCourses.Select(tCourse =>
                (tCourse.Id,
                 tCourse.Course.Name,
                 tCourse.Course.Description)
                ).ToList();

            return tCourseList;
        }

        //
        // A partir de aquí vuestros métodos
        //

        // Caso 1: Hector
        public List<Teacher> ListTeachersOfTaughtCourse(int taughtCourseId)
        {
            // Validate the existence of the TaughtCourse
            var chosenCourse = dal.GetById<TaughtCourse>(taughtCourseId);
            if (chosenCourse == null)
            {
                throw new ServiceException($"Taught course with ID {taughtCourseId} does not exist.");
            }

            IEnumerable<Teacher> allTeachers = dal.GetAll<Teacher>();
            List<Teacher> availableTeachers = new List<Teacher>();
            foreach (Teacher t in allTeachers)
            {
                if (t.IsScheduleCompatibleWith(chosenCourse)) availableTeachers.Add(t);
            }
            // Mostrar esta lista de available teachers en la pantalla
            return availableTeachers;

        }
        public void AssignTeacherToTaughtCourse(int taughtCourseId, string teacherID)
        {
            var chosenCourse = dal.GetById<TaughtCourse>(taughtCourseId);
            if (chosenCourse == null)
            {
                throw new ServiceException($"Taught course with ID {taughtCourseId} does not exist.");
            }
            var selectedTeacher = dal.GetById<Teacher>(teacherID);
            if (selectedTeacher == null)
            {
                throw new ServiceException($"The teacher with ID {teacherID} does not exist.");
            }
            chosenCourse.AssignTeacher(selectedTeacher);

            dal.Commit();
        }

        // Caso 2: Rubén

        public List<string> ListTaughtCourses()
        {
            List<string> list = new List<string>();
            foreach (TaughtCourse tc in dal.GetAll<TaughtCourse>())
            {
                list.Add(tc.Id.ToString());
            }
            return list;
        }

        public TaughtCourse GetTaughtCourseWithId(int id)
        {
            return dal.GetById<TaughtCourse>(id);
        }

        public List<string> ListClassroomsOfTaughtCourse(int taughtCourseId)
        {
            var chosenCourse = dal.GetById<TaughtCourse>(taughtCourseId);
            if (chosenCourse == null)
            {
                throw new ServiceException($"Taught course with ID {taughtCourseId} does not exist.");
            }                       // Ahora se muestran los detalles del curso en la pantalla Y SI YA HAY ALGUNA CLASE ASIGNADA

            IEnumerable<Classroom> allClassrooms = dal.GetAll<Classroom>();
            List<Classroom> availableClassrooms = new List<Classroom>();
            foreach (Classroom c in allClassrooms)
            {
                if (c.IsScheduleCompatibleWith(chosenCourse)) availableClassrooms.Add(c);
            }
            // Mostrar esta lista de available teachers en la pantalla
            return availableClassrooms.Select(e => (e.Name)).ToList();
        }

        public void AssignClassroomToTaughtCourse(int chosenCourse, string selectedClassroom)
        {
            // Tiene q ser asignar taughtCourse a Classroom por como esta hecho el diagrama
            dal.GetWhere<Classroom>(x => x.Name == selectedClassroom).ToList()[0].AssignTaughtCourse(dal.GetById<TaughtCourse>(chosenCourse));
            
            dal.Commit();
        }

        // Caso 3: Gabriel
        public void AddEnrollment(DateTime enrollmentDate, bool uniquePaymentTaughtCourse, Student s, TaughtCourse tc)
        {

            //If at 5 the student is not found the system will ask whether a new student must be added.
            //If so, the student info will be requested, and the student will be added
            if (!StudentExist(s))
                throw new ServiceException($"Student {s} does not exist."); 

            DateTime courseStartDate = GetTaughtCourseStartDate(tc.Id); if (courseStartDate <= DateTime.Now) throw new ServiceException("The selected course has already started. Enrollment is not allowed.");
            var existingEnrollment = dal.GetAll<Enrollment>().FirstOrDefault(e => e.Student.Id == s.Id && e.TaughtCourse.Id == tc.Id);

            var classroom = GetClassroomForCourse(tc.Id);
            int currentEnrollmentCount = GetEnrollmentCount(tc.Id);
            if (classroom.MaxCapacity <= currentEnrollmentCount)
            {
                throw new ServiceException("The classroom capacity has been exceeded. Cannot enroll the student.");
            }

            if (existingEnrollment == null)
            {
                Enrollment enrollment = new Enrollment(enrollmentDate, uniquePaymentTaughtCourse, s, tc);
                dal.Insert(enrollment);
                dal.Commit();
            }
            else
            {
                // Throw an exception if the student is already enrolled
                throw new ServiceException($"The student with id {s.Id} and name {s.Name} is already enrolled in course {tc.Course} with id {tc.Id}!");
            }
        }
        public bool StudentExist(Student s)
        {
            var existingStudent = dal.GetAll<Student>().FirstOrDefault(st => st.Id == s.Id);
            return existingStudent != null;
        }

        public void AddStudent(String dni, String student, String address, int zipCode, String iban)
        {
            Student s = new Student(
                                address,
                                dni,
                                student,
                                zipCode,
                                iban
                            );
            if (!StudentExist(s)) {
                dal.Insert(s);
                dal.Commit();
            }
            else {
                throw new ServiceException($"The student with id {s.Id} and name {s.Name} already exists!");
            }

        }

        // Caso 4: Zainab
        public List<(string StudentName, string PaymentType)> ListStudentsOfTaughtCourse(int taughtCourseId)
        {
            // Validate the existence of the TaughtCourse
            var taughtCourse = dal.GetById<TaughtCourse>(taughtCourseId);
            if (taughtCourse == null)
            {
                throw new ServiceException($"Taught course with ID {taughtCourseId} does not exist.");
            }

            // Get and validate enrollments
            var enrollments = dal.GetWhere<Enrollment>(e => e.TaughtCourse.Id == taughtCourseId);
            if (!enrollments.Any())
            {
                throw new ServiceException($"No students are enrolled in the taught course with ID {taughtCourseId}.");
            }

            return enrollments.Select(e =>
                (e.Student.Name, e.UniquePayment ? "Unique Payment" : "Monthly Quotas"))
                .ToList();
        }

        public Student GetStudentById(string studentId)
        {
            return dal.GetById<Student>(studentId);
        }

        public TaughtCourse GetTaughtCourseById(int courseId)
        {
            return dal.GetById<TaughtCourse>(courseId);
        }

        public bool IsStudentEnrolledInCourse(string studentId, int courseId)
        {
            return dal.GetWhere<Enrollment>(e => e.Student.Id == studentId.ToString() && e.TaughtCourse.Id == courseId).Any();
        }


        public int GetEnrollmentCount(int courseId)
        {
            return dal.GetWhere<Enrollment>(e => e.TaughtCourse.Id == courseId).Count();
        }

        public DateTime GetTaughtCourseStartDate(int taughtCourseId)
        {
            var taughtCourse = dal.GetById<TaughtCourse>(taughtCourseId);
            if (taughtCourse == null)
                throw new ServiceException($"Taught course with ID {taughtCourseId} does not exist.");

            return taughtCourse.StartDateTime;
        }
        public Classroom GetClassroomForCourse(int taughtCourseId)
        {
            // Retrieve the TaughtCourse by its ID
            var taughtCourse = dal.GetById<TaughtCourse>(taughtCourseId);
            if (taughtCourse == null)
            {
                throw new ServiceException($"Taught course with ID {taughtCourseId} does not exist.");
            }

            // Return the classroom associated with the taught course
            return taughtCourse.Classroom;
        }



    }
}


