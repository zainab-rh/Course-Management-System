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

namespace GestAcaUI {
    public partial class TeacherTaughtForm : Form {
        private IGestAcaService service;
        public TeacherTaughtForm(IGestAcaService service) {
            InitializeComponent();
            this.service = service;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string courseIDText = txtCourseID.Text;
            int courseID;
            if (int.TryParse(courseIDText, out courseID))
            {
                List<Teacher> teacher = service.ListTeachersOfTaughtCourse(courseID);
                populateData(teacher);
            }
            else
            {
                MessageBox.Show("Introduce a valid Course ID!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void populateData(List<Teacher> teacher)
        {
            dgvResults.Rows.Clear();
            teacher.ForEach(e => {
                dgvResults.Rows.Add(e.Name, e.Id);
            });
        }

        private void btn_assign_Click(object sender, EventArgs e)
        {
            string courseIDText = txtCourseID.Text;
            int courseID;
            int.TryParse(courseIDText, out courseID);

            string teacherIDText = textTeacherName.Text;
            service.AssignTeacherToTaughtCourse(courseID, teacherIDText);

        }

    }
}
