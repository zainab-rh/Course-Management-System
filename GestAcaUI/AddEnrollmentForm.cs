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

namespace GestAcaUI
{
    public partial class AddEnrollmentForm : Form
    {
        private IGestAcaService service;
        public AddEnrollmentForm(IGestAcaService service)
        {
            InitializeComponent();
            this.service = service;
            LoadTaughtCourses();
            EnsureDataGridViewColumns();
        }
        private void LoadTaughtCourses()
        {
            try
            {
                var taughtCourses = service.GetTaughtCoursesData()
                    .Where(tc => service.GetTaughtCourseStartDate(tc.id) > DateTime.Now) 
                    .Select(tc => new { tc.id, tc.name }) 
                    .ToList();

                cmbTaughtCourses.DataSource = taughtCourses;
                cmbTaughtCourses.DisplayMember = "name";
                cmbTaughtCourses.ValueMember = "id";
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnsureDataGridViewColumns()
        {
            
            if (dgvStudentInfo.Columns.Count == 0)
            {
                dgvStudentInfo.Columns.Add("Id", "Student ID");
                dgvStudentInfo.Columns.Add("Name", "Student Name");
                dgvStudentInfo.Columns.Add("Address", "Student Address");
            }
        }
        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            
            string studentId = txtStudentID.Text.Trim();
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            var student = service.GetStudentById(studentId);
            if (student == null)
            {
                var result = MessageBox.Show("Student not found. Do you want to add a new student?", "Student Not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    using (var addStudentForm = new AddStudentForm(service))
                    {
                        addStudentForm.ShowDialog();
                    }
                }
                return;
            }


            
            EnsureDataGridViewColumns();

            dgvStudentInfo.Rows.Clear();  
            dgvStudentInfo.Rows.Add(student.Id, student.Name, student.Address);
        }

        
        private void btnConfirmEnrollment_Click(object sender, EventArgs e)
        {
            if (cmbTaughtCourses.SelectedValue == null || string.IsNullOrEmpty(txtStudentID.Text.Trim()))
            {
                MessageBox.Show("Please select a taught course and provide a valid Student ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int courseId = (int)cmbTaughtCourses.SelectedValue;
            string studentId = txtStudentID.Text.Trim();

            try
            {
                var student = service.GetStudentById(studentId);
                var course = service.GetTaughtCourseById(courseId);

                if (student == null || course == null)
                {
                    MessageBox.Show("Invalid student or course selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                if (service.IsStudentEnrolledInCourse(student.Id, course.Id))
                {
                    MessageBox.Show("The student is already enrolled in the selected course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var classroom = service.GetClassroomForCourse(course.Id);
                int enrolledCount = service.GetEnrollmentCount(course.Id);
                if (classroom != null && enrolledCount >= classroom.MaxCapacity)
                {
                    MessageBox.Show("The classroom capacity has been exceeded. Please select another course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                service.AddEnrollment(DateTime.Now, false, student, course);
                MessageBox.Show("Student successfully enrolled!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (ServiceException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}

