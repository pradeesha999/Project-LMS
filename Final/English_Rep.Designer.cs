
namespace Final
{
    partial class English_Rep
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
            this.registrationstuengBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registration_stu_engTableAdapter = new Final.StudentTableAdapters.Registration_stu_engTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstuengBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet11";
            reportDataSource1.Value = this.registrationstuengBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Final.eng_rep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1195, 757);
            this.reportViewer1.TabIndex = 0;
            // 
            // student
            // 
            this.student.DataSetName = "Student";
            this.student.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registrationstuengBindingSource
            // 
            this.registrationstuengBindingSource.DataMember = "Registration_stu_eng";
            this.registrationstuengBindingSource.DataSource = this.student;
            // 
            // registration_stu_engTableAdapter
            // 
            this.registration_stu_engTableAdapter.ClearBeforeFill = true;
            // 
            // English_Rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 760);
            this.Controls.Add(this.reportViewer1);
            this.Name = "English_Rep";
            this.Text = "English_Rep";
            this.Load += new System.EventHandler(this.English_Rep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstuengBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student student;
        private System.Windows.Forms.BindingSource registrationstuengBindingSource;
        private StudentTableAdapters.Registration_stu_engTableAdapter registration_stu_engTableAdapter;
    }
}