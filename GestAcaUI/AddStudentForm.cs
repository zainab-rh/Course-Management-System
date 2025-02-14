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
    public partial class AddStudentForm : Form {
        IGestAcaService service;
        public AddStudentForm(IGestAcaService service) {
            InitializeComponent();
            this.service = service;
        }

        private void btnAddStudent_Click(object sender, EventArgs e) {
            if (checkInputs()) {
                int zipCode = parseZipCode();
                if(zipCode == -1) {
                    MessageBox.Show("The Zip code is invalid", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try {
                    service.AddStudent(txtDNI.Text, txtStudentName.Text, txtAddress.Text, zipCode, txtIBAN.Text);
                    clearFields();
                    MessageBox.Show("Student added", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(ServiceException se) {
                    MessageBox.Show(se.Message, "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else {
                MessageBox.Show("Fill all the fields", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clearFields() {
            txtDNI.Clear();
            txtStudentName.Clear();
            txtAddress.Clear();
            txtZipCode.Clear();
            txtIBAN.Clear();
        }
        private int parseZipCode() {
            int zipCode;
            if (int.TryParse(txtZipCode.Text, out zipCode)) {
                return zipCode;
            }
            else {
                return -1;
            }
        }
        private bool checkInputs() {
            if (string.IsNullOrEmpty(txtDNI.Text) ||
                string.IsNullOrEmpty(txtStudentName.Text) ||
                string.IsNullOrEmpty(txtAddress.Text) ||
                string.IsNullOrEmpty(txtIBAN.Text)) {
                return false;
            }
            return true;

        }
    } }
