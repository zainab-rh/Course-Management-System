using GestAca.Entities;
using GestAca.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GestAcaUI {
    public partial class StudentsEnrolledForm : Form {
        private IGestAcaService service;
        public StudentsEnrolledForm(IGestAcaService service) {
            InitializeComponent();
            this.service = service;
        }

        private void btnSearch_Click(object sender, EventArgs e) {
            string courseIDText = txtCourseID.Text;
            int courseID;
            if (int.TryParse(courseIDText, out courseID)) {
                try {
                    List<(string StudentName, string PaymentType)> students = service.ListStudentsOfTaughtCourse(courseID);
                    populateData(students);
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("There's no Course with the provided ID nor Students enrolled!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else {
                MessageBox.Show("Introduce a valid Course ID!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void populateData(List<(string StudentName, string PaymentType)> students) {
            dgvResults.Rows.Clear();
            students.ForEach(student => {
                dgvResults.Rows.Add(student.StudentName, student.PaymentType);
            });
        }

        private void btnShowCourses_Click(object sender, EventArgs e) {
            ShowCoursesForm showCourses = new ShowCoursesForm(service);
            showCourses.ShowDialog();
        }

        private void txtCourseID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
