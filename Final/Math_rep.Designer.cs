namespace Final
{
    partial class Math_rep
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
            this.registrationstumathBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.student = new Final.Student();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.registration_stu_mathTableAdapter = new Final.StudentTableAdapters.Registration_stu_mathTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstumathBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.student)).BeginInit();
            this.SuspendLayout();
            // 
            // registrationstumathBindingSource
            // 
            this.registrationstumathBindingSource.DataMember = "Registration_stu_math";
            this.registrationstumathBindingSource.DataSource = this.student;
            // 
            // student
            // 
            this.student.DataSetName = "Student";
            this.student.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet11";
            reportDataSource1.Value = this.registrationstumathBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Final.math_rep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1324, 843);
            this.reportViewer1.TabIndex = 0;
            // 
            // registration_stu_mathTableAdapter
            // 
            this.registration_stu_mathTableAdapter.ClearBeforeFill = true;
            // 
            // Math_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 843);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Math_rep";
            this.Text = " ";
            this.Load += new System.EventHandler(this.Math_rep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.registrationstumathBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.student)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student student;
        private System.Windows.Forms.BindingSource registrationstumathBindingSource;
        private StudentTableAdapters.Registration_stu_mathTableAdapter registration_stu_mathTableAdapter;
    }
}