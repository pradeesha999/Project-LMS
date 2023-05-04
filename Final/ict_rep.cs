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
    public partial class ict_rep : Form
    {
        public ict_rep()
        {
            InitializeComponent();
        }

        private void ict_rep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student.Registration_stu_ict' table. You can move, or remove it, as needed.
            this.registration_stu_ictTableAdapter.Fill(this.student.Registration_stu_ict);

            this.reportViewer1.RefreshReport();
        }
    }
}
