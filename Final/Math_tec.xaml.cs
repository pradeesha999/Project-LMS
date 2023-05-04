using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Final
{
    /// <summary>
    /// Interaction logic for Math_tec.xaml
    /// </summary>
    public partial class Math_tec : Window
    {
        public Math_tec()
        {
            InitializeComponent();
            LoadData();
        }
        
        Class_File c1 = new Class_File();   
        private void btn_browse_ass_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txt_filepath.Text = dlg.FileName;
        }
        private void btn_upload_ass_Click(object sender, RoutedEventArgs e)
        {
            SaveFile1(txt_filepath.Text);
        }
        private void SaveFile1(string filePath)
        {
            try
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);

                    var fi = new FileInfo(filePath);
                    string extn = fi.Extension;
                    string name = fi.Name;

                    string query = "INSERT INTO Maths (FileName,Data, Extention)VALUES(@name,@data,@extn)";

                    using (SqlConnection cn = GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@data", System.Data.SqlDbType.VarBinary).Value = buffer;
                        cmd.Parameters.Add("@extn", System.Data.SqlDbType.Char).Value = extn;
                        cn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("File Saved");
                        }
                        else
                        {
                            MessageBox.Show("File Could not be Saved");
                        }
                        cn.Close();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Document");
            }
        }
        private void btn_browse_mat_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            txt_filepath_Copy.Text = dlg.FileName;
        }
        private void btn_upload_mat_Click(object sender, RoutedEventArgs e)
        {
            SaveFile(txt_filepath_Copy.Text);
        }
        private void SaveFile(string filePath)
        {
            try
            {
                using (Stream stream = File.OpenRead(filePath))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);

                    var fi = new FileInfo(filePath);
                    string extn = fi.Extension;
                    string name = fi.Name;

                    string query = "INSERT INTO Math_stud_mat (FileName,Data, Extention)VALUES(@name,@data,@extn)";

                    using (SqlConnection cn = GetConnection())
                    {
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@data", System.Data.SqlDbType.VarBinary).Value = buffer;
                        cmd.Parameters.Add("@extn", System.Data.SqlDbType.Char).Value = extn;
                        cn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("File Saved");
                        }
                        else
                        {
                            MessageBox.Show("File Could not be Saved");
                        }
                        cn.Close();

                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Document");
            }
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        }
        private void LoadData()
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "SELECT Email,msg FROM feedback_math";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtg_fb_math.ItemsSource = dt.DefaultView;
                    dtg_fb_math.AutoGenerateColumns = true;
                    dtg_fb_math.CanUserAddRows = false;
                }
            }
        }
        private void btn_logout_Click(object sender, RoutedEventArgs e)
        {
            Teacher_log log = new Teacher_log();
            log.Show();
            Close();
        }
        private bool isDragging = false;
        private Point startPoint;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                isDragging = true;
                startPoint = e.GetPosition(this);
            }
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && e.LeftButton == MouseButtonState.Pressed)
            {
                Point currentPosition = e.GetPosition(this);
                double deltaX = currentPosition.X - startPoint.X;
                double deltaY = currentPosition.Y - startPoint.Y;

                Left += deltaX;
                Top += deltaY;
            }
        }
        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Btn_Detials_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection cn = GetConnection())
                {

                    string query = "Select * from Registration_teach where Subject = 'Maths'";
                    Detials_tec details_Tec = new Detials_tec();
                    DataRow row = c1.Getdata(query, 0);
                    details_Tec.Txt_bloc_fname.Text = row["FirstName"].ToString();
                    details_Tec.Txt_bloc_lname.Text = row["LastName"].ToString();
                    details_Tec.Txt_bloc_mail.Text = row["Email"].ToString();
                    details_Tec.Txt_bloc_pass.Text = row["Password"].ToString();
                    details_Tec.Txt_subject.Text = row["Subject"].ToString();
                    details_Tec.Show();
                }  
            }
            catch (Exception) 
            {
                MessageBox.Show("Error");
            }
            
        }

        private void Btn_Report_Click(object sender, RoutedEventArgs e)
        {
            Math_rep m1 = new Math_rep();
            m1.Show();
        }
    }
}
