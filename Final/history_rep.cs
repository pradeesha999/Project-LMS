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
    public partial class history_rep : Form
    {
        public history_rep()
        {
            InitializeComponent();
        }

        private void history_rep_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student.Registration_stu_history' table. You can move, or remove it, as needed.
            this.registration_stu_historyTableAdapter.Fill(this.student.Registration_stu_history);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
