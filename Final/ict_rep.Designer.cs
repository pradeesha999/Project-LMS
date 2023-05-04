namespace Final
{
    partial class ict_rep
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.student = new Final.Student();
            this.registrationstuictBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registration_stu_ictTableAdapter = new Final.StudentTableAdapters.Registration_stu_ictTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstuictBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet11";
            reportDataSource1.Value = this.registrationstuictBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Final.history_rep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1138, 877);
            this.reportViewer1.TabIndex = 0;
            // 
            // student
            // 
            this.student.DataSetName = "Student";
            this.student.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registrationstuictBindingSource
            // 
            this.registrationstuictBindingSource.DataMember = "Registration_stu_ict";
            this.registrationstuictBindingSource.DataSource = this.student;
            // 
            // registration_stu_ictTableAdapter
            // 
            this.registration_stu_ictTableAdapter.ClearBeforeFill = true;
            // 
            // ict_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 878);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ict_rep";
            this.Text = "ict_rep";
            this.Load += new System.EventHandler(this.ict_rep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstuictBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student student;
        private System.Windows.Forms.BindingSource registrationstuictBindingSource;
        private StudentTableAdapters.Registration_stu_ictTableAdapter registration_stu_ictTableAdapter;
    }
}