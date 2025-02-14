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
    public partial class ShowCoursesForm : Form {
        private IGestAcaService service;
        public ShowCoursesForm(IGestAcaService service) {
            InitializeComponent();
            this.service = service;

            populateCourses();
        }

        private void populateCourses() {
            dgvResults.Rows.Clear();
            //List<(int id, string name, string desc)> courses = service.GetTaughtCoursesData();
            //courses.ForEach(course => {
            //    dgvResults.Rows.Add(course.id, course.name, course.desc);
            //});
        }

        private void ShowCoursesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
