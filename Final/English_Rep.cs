using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    public partial class English_Rep : Form
    {
        public English_Rep()
        {
            InitializeComponent();
        }

        private void English_Rep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student.Registration_stu_eng' table. You can move, or remove it, as needed.
            this.registration_stu_engTableAdapter.Fill(this.student.Registration_stu_eng);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
