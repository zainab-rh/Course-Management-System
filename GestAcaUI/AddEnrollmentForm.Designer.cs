namespace GestAcaUI
{
    partial class AddEnrollmentForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.pnlInputs = new System.Windows.Forms.Panel();
            this.lblTaughtCourseList = new System.Windows.Forms.Label();
            this.cmbTaughtCourses = new System.Windows.Forms.ComboBox();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.btnSearchStudent = new System.Windows.Forms.Button();
            this.lblStudentDetails = new System.Windows.Forms.Label();
            this.dgvStudentInfo = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnConfirmEnrollment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.pnlInputs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInfo)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1142, 78);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Enroll a Student";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.pnlInputs, 0, 0);
            this.mainPanel.Controls.Add(this.dgvStudentInfo, 0, 2);
            this.mainPanel.Controls.Add(this.pnlButtons, 0, 3);
            this.mainPanel.Controls.Add(this.lblStudentDetails, 0, 1);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 78);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 4;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.mainPanel.Size = new System.Drawing.Size(1142, 635);
            this.mainPanel.TabIndex = 1;
            // 
            // pnlInputs
            // 
            this.pnlInputs.Controls.Add(this.lblTaughtCourseList);
            this.pnlInputs.Controls.Add(this.cmbTaughtCourses);
            this.pnlInputs.Controls.Add(this.lblStudentID);
            this.pnlInputs.Controls.Add(this.txtStudentID);
            this.pnlInputs.Controls.Add(this.btnSearchStudent);
            this.pnlInputs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInputs.Location = new System.Drawing.Point(0, 0);
            this.pnlInputs.Margin = new System.Windows.Forms.Padding(0);
            this.pnlInputs.Name = "pnlInputs";
            this.pnlInputs.Size = new System.Drawing.Size(1142, 151);
            this.pnlInputs.TabIndex = 0;
            // 
            // lblTaughtCourseList
            // 
            this.lblTaughtCourseList.AutoSize = true;
            this.lblTaughtCourseList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaughtCourseList.Location = new System.Drawing.Point(37, 25);
            this.lblTaughtCourseList.Name = "lblTaughtCourseList";
            this.lblTaughtCourseList.Size = new System.Drawing.Size(246, 29);
            this.lblTaughtCourseList.TabIndex = 0;
            this.lblTaughtCourseList.Text = "Select Taught Course";
            // 
            // cmbTaughtCourses
            // 
            this.cmbTaughtCourses.Location = new System.Drawing.Point(353, 30);
            this.cmbTaughtCourses.Name = "cmbTaughtCourses";
            this.cmbTaughtCourses.Size = new System.Drawing.Size(400, 24);
            this.cmbTaughtCourses.TabIndex = 1;
            // 
            // lblStudentID
            // 
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentID.Location = new System.Drawing.Point(37, 82);
            this.lblStudentID.Name = "lblStudentID";
            this.lblStudentID.Size = new System.Drawing.Size(187, 29);
            this.lblStudentID.TabIndex = 2;
            this.lblStudentID.Text = "Enter Student ID";
            // 
            // txtStudentID
            // 
            this.txtStudentID.Location = new System.Drawing.Point(353, 87);
            this.txtStudentID.Name = "txtStudentID";
            this.txtStudentID.Size = new System.Drawing.Size(350, 22);
            this.txtStudentID.TabIndex = 3;
            // 
            // btnSearchStudent
            // 
            this.btnSearchStudent.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSearchStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchStudent.Location = new System.Drawing.Point(756, 87);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(100, 30);
            this.btnSearchStudent.TabIndex = 4;
            this.btnSearchStudent.Text = "Search";
            this.btnSearchStudent.UseVisualStyleBackColor = true;
            this.btnSearchStudent.Click += new System.EventHandler(this.btnSearchStudent_Click);
            // 
            // lblStudentDetails
            // 
            this.lblStudentDetails.AutoSize = true;
            this.lblStudentDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentDetails.Location = new System.Drawing.Point(20, 151);
            this.lblStudentDetails.Margin = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblStudentDetails.Name = "lblStudentDetails";
            this.lblStudentDetails.Size = new System.Drawing.Size(150, 25);
            this.lblStudentDetails.TabIndex = 1;
            this.lblStudentDetails.Text = "Student Details:";
  
            // 
            // dgvStudentInfo
            // 
            this.dgvStudentInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudentInfo.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dgvStudentInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudentInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudentInfo.Location = new System.Drawing.Point(0, 198);
            this.dgvStudentInfo.Margin = new System.Windows.Forms.Padding(0);
            this.dgvStudentInfo.Name = "dgvStudentInfo";
            this.dgvStudentInfo.RowHeadersWidth = 51;
            this.dgvStudentInfo.Size = new System.Drawing.Size(1142, 289);
            this.dgvStudentInfo.TabIndex = 2;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnConfirmEnrollment);
            this.pnlButtons.Controls.Add(this.btnCancel);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlButtons.Location = new System.Drawing.Point(0, 487);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(1142, 148);
            this.pnlButtons.TabIndex = 3;
            // 
            // btnConfirmEnrollment
            // 
            this.btnConfirmEnrollment.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnConfirmEnrollment.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnConfirmEnrollment.FlatAppearance.BorderSize = 3;
            this.btnConfirmEnrollment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmEnrollment.Location = new System.Drawing.Point(220, 15);
            this.btnConfirmEnrollment.Name = "btnConfirmEnrollment";
            this.btnConfirmEnrollment.Size = new System.Drawing.Size(142, 40);
            this.btnConfirmEnrollment.TabIndex = 0;
            this.btnConfirmEnrollment.Text = "Confirm";
            this.btnConfirmEnrollment.UseVisualStyleBackColor = false;
            this.btnConfirmEnrollment.Click += new System.EventHandler(this.btnConfirmEnrollment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Silver;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(676, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(144, 40);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddEnrollmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 713);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.lbTitle);
            this.Name = "AddEnrollmentForm";
            this.Text = "Add Enrollment";
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            this.pnlInputs.ResumeLayout(false);
            this.pnlInputs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudentInfo)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Panel pnlInputs;
        private System.Windows.Forms.Label lblTaughtCourseList;
        private System.Windows.Forms.ComboBox cmbTaughtCourses;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Button btnSearchStudent;
        private System.Windows.Forms.Label lblStudentDetails;
        private System.Windows.Forms.DataGridView dgvStudentInfo;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnConfirmEnrollment;
        private System.Windows.Forms.Button btnCancel;

        #endregion
    }
}
