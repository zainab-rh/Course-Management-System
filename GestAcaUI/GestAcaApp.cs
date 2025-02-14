using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestAca.Services;


namespace GestAcaUI {
    public partial class GestAcaApp : Form {
        private IGestAcaService service;
        public GestAcaApp(IGestAcaService service) {
            InitializeComponent();
            this.service = service;
        }

        private void GestAcaApp_Load(object sender, EventArgs e) {

        }

        private void btnTeacherTaught_Click_1(object sender, EventArgs e) {
            Console.WriteLine("Teacher Taught");
            TeacherTaughtForm teacherTaughtForm = new TeacherTaughtForm(service);
            teacherTaughtForm.ShowDialog();
        }

        private void btnClassroomTaught_Click_1(object sender, EventArgs e) {
            Console.WriteLine("Classroom Taught");
            AssignClassroomForm assignClassroomForm = new AssignClassroomForm(service);
            assignClassroomForm.ShowDialog();
        }

        private void btnAddEnrollment_Click(object sender, EventArgs e) {
            Console.WriteLine("Add Enrollment Taught");
            AddEnrollmentForm addEnrollmentForm = new AddEnrollmentForm(service);
            addEnrollmentForm.ShowDialog();
        }

        private void btnListEnrolled_Click(object sender, EventArgs e) {
            Console.WriteLine("List Students");
            StudentsEnrolledForm listEnrolledForm = new StudentsEnrolledForm(service);
            listEnrolledForm.ShowDialog();
        }
    }
}
