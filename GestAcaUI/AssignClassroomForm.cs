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
    public partial class AssignClassroomForm : Form
    {
        private IGestAcaService service;

        public AssignClassroomForm(IGestAcaService service)
        {
            InitializeComponent();
            this.service = service;
            LoadData();
        }

        public void LoadData()
        {
            dataGridView1.Rows.Clear();
            service.ListTaughtCourses().ForEach(str => {
                dataGridView1.Rows.Add(str);
            });
        }

        private void tc_cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView2.Rows.Clear();
            int selectedValue = int.Parse((string)dataGridView1.SelectedCells[0].Value);
            service.ListClassroomsOfTaughtCourse(selectedValue).ForEach(str => {
                dataGridView2.Rows.Add(str);
            });

            // Show details
            TaughtCourse selectedCourse = service.GetTaughtCourseWithId(selectedValue);
            label_id.Text = selectedCourse.Id.ToString();
            label_course.Text = selectedCourse.Course.Name;
            label_teaching_day.Text = selectedCourse.TeachingDay;
            label_startdatetime.Text = selectedCourse.StartDateTime.ToLongDateString();
            label_enddate.Text = selectedCourse.EndDate.ToShortDateString();
            label_sessionduration.Text = selectedCourse.SessionDuration.ToString() + " mins";
            label_quotas.Text = selectedCourse.Quotas.ToString();
            label_totalprice.Text = selectedCourse.TotalPrice.ToString();
    }

        private void cl_cellClicked(object sender, DataGridViewCellEventArgs e)
        {
            int taughtCourse = int.Parse((string)dataGridView1.SelectedCells[0].Value);
            string classroom = (string)dataGridView2.SelectedCells[0].Value;
            MessageBox.Show(this, "Assigned classroom to taught course\nTaughtCourse: " + taughtCourse.ToString() + ", Classroom" + classroom, "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            service.AssignClassroomToTaughtCourse(taughtCourse, classroom);
            this.Close();
        }
    }
}