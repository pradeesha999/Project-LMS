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
    public partial class Math_rep : Form
    {
        public Math_rep()
        {
            InitializeComponent();
        }

        private void Math_rep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student.Registration_stu_math' table. You can move, or remove it, as needed.
            this.registration_stu_mathTableAdapter.Fill(this.student.Registration_stu_math);

            this.reportViewer1.RefreshReport();
        }
    }
}
