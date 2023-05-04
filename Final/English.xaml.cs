using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for English.xaml
    /// </summary>
    public partial class English : Window
    {
        public English()
        {
            InitializeComponent();
            LoadData();
            LoadData2();
        }
        Class_File c1 = new Class_File();
        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        }

        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRows = dtg_assdown.SelectedItems;
                foreach (var row in selectedRows)
                {
                    int id = (int)((DataRowView)row)[0];
                    OpenFile(id);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Please check again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OpenFile(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "SELECT Data,FileName,Extention FROM English WHERE ID =@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["data"];
                    var extn = reader["Extention"].ToString();
                    var newFilename = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFilename, data);
                    System.Diagnostics.Process.Start(newFilename);
                }
            }
        }
        private void LoadData()
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "SELECT ID,FileName,Extention FROM English";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtg_assdown.ItemsSource = dt.DefaultView;
                    dtg_assdown.AutoGenerateColumns = true;
                    dtg_assdown.CanUserAddRows = false;
                }
            }
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btn_open_2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedRows = dtg_studDown.SelectedItems;
                foreach (var row in selectedRows)
                {
                    int id = (int)((DataRowView)row)[0];
                    OpenFile2(id);
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Please check again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        private void OpenFile2(int id)
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "SELECT Data,FileName,Extention FROM English_stud_mat WHERE ID =@id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cn.Open();
                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var name = reader["FileName"].ToString();
                    var data = (byte[])reader["data"];
                    var extn = reader["Extention"].ToString();
                    var newFilename = name.Replace(extn, DateTime.Now.ToString("ddMMyyyyhhmmss")) + extn;
                    File.WriteAllBytes(newFilename, data);
                    System.Diagnostics.Process.Start(newFilename);
                }
            }
        }
        private void LoadData2()
        {
            using (SqlConnection cn = GetConnection())
            {
                string query = "SELECT ID,FileName,Extention FROM English_stud_mat";
                SqlDataAdapter adp = new SqlDataAdapter(query, cn);
                System.Data.DataTable dt = new System.Data.DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtg_studDown.ItemsSource = dt.DefaultView;
                    dtg_studDown.AutoGenerateColumns = true;
                    dtg_studDown.CanUserAddRows = false;
                }
            }
        }
        private void btn_refresh_2_Click(object sender, RoutedEventArgs e)
        {
            LoadData2();
        }

        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txt_message.Text))
                {
                    txt_errorMsg.Text = "Massege Body can not be blank!";
                    txt_message.Focus();
                }
                else
                {
                    string query = "Insert into feedback_eng values('" + Txt_SenderEmail.Text + "','" + txt_message.Text + "')";
                    int i = c1.Insert(query);
                    if (i == 1)
                    {
                        MessageBox.Show("Message sent Successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        txt_errorMsg.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Message Not sent", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Database Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Please check again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
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
    }
}
