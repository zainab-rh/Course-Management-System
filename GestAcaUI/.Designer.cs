using System;

namespace GestAcaUI {
    partial class GestAcaApp {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lbTitle = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.TableLayoutPanel();
            this.btnTeacherTaught = new System.Windows.Forms.Button();
            this.btnClassroomTaught = new System.Windows.Forms.Button();
            this.btnAddEnrollment = new System.Windows.Forms.Button();
            this.btnListEnrolled = new System.Windows.Forms.Button();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(0, 0);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(1280, 60);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "GestAca";
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainPanel
            // 
            this.mainPanel.ColumnCount = 1;
            this.mainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainPanel.Controls.Add(this.btnTeacherTaught, 0, 0);
            this.mainPanel.Controls.Add(this.btnClassroomTaught, 0, 1);
            this.mainPanel.Controls.Add(this.btnAddEnrollment, 0, 2);
            this.mainPanel.Controls.Add(this.btnListEnrolled, 0, 3);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 60);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.RowCount = 4;
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.mainPanel.Size = new System.Drawing.Size(1280, 660);
            this.mainPanel.TabIndex = 1;
            // 
            // btnTeacherTaught
            // 
            this.btnTeacherTaught.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTeacherTaught.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTeacherTaught.Location = new System.Drawing.Point(365, 27);
            this.btnTeacherTaught.Name = "btnTeacherTaught";
            this.btnTeacherTaught.Size = new System.Drawing.Size(550, 110);
            this.btnTeacherTaught.TabIndex = 0;
            this.btnTeacherTaught.Text = "Assign Teacher to Taught Course";
            this.btnTeacherTaught.UseVisualStyleBackColor = true;
            this.btnTeacherTaught.Click += new System.EventHandler(this.btnTeacherTaught_Click_1);
            // 
            // btnClassroomTaught
            // 
            this.btnClassroomTaught.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClassroomTaught.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassroomTaught.Location = new System.Drawing.Point(365, 192);
            this.btnClassroomTaught.Name = "btnClassroomTaught";
            this.btnClassroomTaught.Size = new System.Drawing.Size(550, 110);
            this.btnClassroomTaught.TabIndex = 1;
            this.btnClassroomTaught.Text = "Assign Classroom to Taught Course";
            this.btnClassroomTaught.UseVisualStyleBackColor = true;
            this.btnClassroomTaught.Click += new System.EventHandler(this.btnClassroomTaught_Click_1);
            // 
            // btnAddEnrollment
            // 
            this.btnAddEnrollment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddEnrollment.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddEnrollment.Location = new System.Drawing.Point(365, 357);
            this.btnAddEnrollment.Name = "btnAddEnrollment";
            this.btnAddEnrollment.Size = new System.Drawing.Size(550, 110);
            this.btnAddEnrollment.TabIndex = 2;
            this.btnAddEnrollment.Text = "Add New Enrollment";
            this.btnAddEnrollment.UseVisualStyleBackColor = true;
            this.btnAddEnrollment.Click += new System.EventHandler(this.btnAddEnrollment_Click);
            // 
            // btnListEnrolled
            // 
            this.btnListEnrolled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnListEnrolled.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListEnrolled.Location = new System.Drawing.Point(365, 522);
            this.btnListEnrolled.Name = "btnListEnrolled";
            this.btnListEnrolled.Size = new System.Drawing.Size(550, 110);
            this.btnListEnrolled.TabIndex = 3;
            this.btnListEnrolled.Text = "List Students Enrolled in Course";
            this.btnListEnrolled.UseVisualStyleBackColor = true;
            this.btnListEnrolled.Click += new System.EventHandler(this.btnListEnrolled_Click);
            // 
            // GestAcaApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.lbTitle);
            this.Name = "GestAcaApp";
            this.Text = "GestAca";
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TableLayoutPanel mainPanel;
        private System.Windows.Forms.Button btnTeacherTaught;
        private System.Windows.Forms.Button btnClassroomTaught;
        private System.Windows.Forms.Button btnAddEnrollment;
        private System.Windows.Forms.Button btnListEnrolled;
    }
}
