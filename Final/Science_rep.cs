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
    public partial class Science_rep : Form
    {
        public Science_rep()
        {
            InitializeComponent();
        }

        private void Science_rep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student.Registration_stu_science' table. You can move, or remove it, as needed.
            this.registration_stu_scienceTableAdapter.Fill(this.student.Registration_stu_science);
            // TODO: This line of code loads data into the 'student.Registration_stu_science' table. You can move, or remove it, as needed.
            this.registration_stu_scienceTableAdapter.Fill(this.student.Registration_stu_science);

            this.reportViewer1.RefreshReport();
        }
    }
}
