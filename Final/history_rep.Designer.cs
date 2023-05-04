namespace Final
{
    partial class history_rep
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
            this.registrationstuhistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.registration_stu_historyTableAdapter = new Final.StudentTableAdapters.Registration_stu_historyTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.student)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstuhistoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet11";
            reportDataSource1.Value = this.registrationstuhistoryBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Final.history_rep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(1, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1318, 804);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // student
            // 
            this.student.DataSetName = "Student";
            this.student.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // registrationstuhistoryBindingSource
            // 
            this.registrationstuhistoryBindingSource.DataMember = "Registration_stu_history";
            this.registrationstuhistoryBindingSource.DataSource = this.student;
            // 
            // registration_stu_historyTableAdapter
            // 
            this.registration_stu_historyTableAdapter.ClearBeforeFill = true;
            // 
            // history_rep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 804);
            this.Controls.Add(this.reportViewer1);
            this.Name = "history_rep";
            this.Text = "history_rep";
            this.Load += new System.EventHandler(this.history_rep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.student)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.registrationstuhistoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Student student;
        private System.Windows.Forms.BindingSource registrationstuhistoryBindingSource;
        private StudentTableAdapters.Registration_stu_historyTableAdapter registration_stu_historyTableAdapter;
    }
}