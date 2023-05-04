using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace Final
{
    /// <summary>  
    /// Interaction logic for MainWindow.xaml  
    /// </summary>   
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }
        MainWindow registration = new MainWindow();
        Home welcome = new Home();
        Teacher_log teclog = new Teacher_log();
        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try 
            {
                if (txtEmail.Text.Length == 0)
                {
                    errormessage.Text = "Enter an email.";
                    txtEmail.Focus();
                }
                else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Enter a valid email.";
                    txtEmail.Select(0, txtEmail.Text.Length);
                    txtEmail.Focus();
                }
                else
                {
                    using (SqlConnection cn = GetConnection())
                    {
                        string email = txtEmail.Text;
                        string password = txtPass.Password;
                        
                        cn.Open();
                        string query = "Select * from Registration_stu where Email='" + email + "'  and password='" + password + "'";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = cmd;
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        if (dataSet.Tables[0].Rows.Count > 0)
                        {
                            string usermail = dataSet.Tables[0].Rows[0]["studentId"].ToString();
                            string username = dataSet.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet.Tables[0].Rows[0]["LastName"].ToString();
                            welcome.TextBlockId.Text = usermail;
                            welcome.TextBlockName.Text = username;//Sending value from one form to another form.  
                            welcome.Show();
                            Close();
                        }
                        else
                        {
                            errormessage.Text = "Sorry! Please enter existing emailid/password.";
                        }
                        cn.Close();
                    }
                }
            }
            catch(SqlException)
            {
                MessageBox.Show("Database Error");
            }
            catch(Exception) 
            {
                MessageBox.Show("Error");
            }
            
        }
        private void Btn_Register_Click(object sender, RoutedEventArgs e)
        {
            registration.Show();
            Close();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e) 
        {
            Application.Current.Shutdown();
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

        private void Btn_Teacherlog_Click(object sender, RoutedEventArgs e)
        {
            teclog.Show();
            Close();
        }
    }
}