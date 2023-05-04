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
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Final
{
    /// <summary>  
    /// Interaction logic for Registration.xaml  
    /// </summary>  
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int eng = 0, math = 0, science = 0, history = 0, ict = 0;
        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        }
        private void Login_Click(object sender, RoutedEventArgs e)//Student login
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        private void Teacher_log_Click(object sender, RoutedEventArgs e)//Teacher login
        {
            Teacher_log teacher = new Teacher_log();
            teacher.Show();
            Close();
        }
        
        private void button2_Click(object sender, RoutedEventArgs e)//Reset
        {
            Reset();
        }
        public void Reset()
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxEmail.Text = "";
            textBoxAddress.Text = "";
            passwordBox1.Password = "";
            passwordBoxConfirm.Password = "";
            chk_eng.IsChecked = false;
            chk_history.IsChecked = false;
            chk_ICT.IsChecked = false;
            chk_science.IsChecked = false;
            chk_math.IsChecked = false;
        }
        private void button3_Click(object sender, RoutedEventArgs e)//Close
        {
            Application.Current.Shutdown();
        }
        private void Chk_eng_Checked(object sender, RoutedEventArgs e)
        {
            if(chk_eng.IsChecked == true)
            {
                eng = 1;
            }
            
        }
        private void Chk_eng_Unchecked(Object sender, RoutedEventArgs e)
        {
            if (chk_eng.IsChecked == false)
            {
                eng = 0;
            }
        }
        private void Chk_history_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_history.IsChecked == true)
            {
                history = 1;
            }
        }
        private void Chk_history_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chk_history.IsChecked == false)
            {
                history = 0;
            }
        }
        private void Chk_science_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_science.IsChecked == true)
            {
                science = 1;
            }
        }
        private void Chk_science_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chk_science.IsChecked == false)
            {
                science = 0;
            }
        }
        private void Chk_ICT_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_ICT.IsChecked == true)
            {
                ict = 1;
            }            
        }
        private void Chk_ICT_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chk_ICT.IsChecked == false)
            {
                ict = 0;
            }
        }
        private void Chk_math_Checked(object sender, RoutedEventArgs e)
        {
            if (chk_math.IsChecked == true)
            {
                math = 1;
            }
        }
        private void Chk_math_Unchecked(object sender, RoutedEventArgs e)
        {
            if (chk_math.IsChecked == false)
            {
                math = 0;
            }
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                string usermail = null;
                using (SqlConnection cn = GetConnection())
                {
                    cn.Open();
                    
                    string query = "Select * from Registration_stu where Email='" + textBoxEmail.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        usermail = dataSet.Tables[0].Rows[0]["Email"].ToString();
                    }
                    else
                    {
                        usermail = null;
                    }
                }
                
                if (string.IsNullOrEmpty(textBoxFirstName.Text))
                {
                    MessageBox.Show("Please Enter the First Name");
                    textBoxFirstName.Focus();
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxFirstName.Text, "^[a-zA-Z]+$"))
                {
                    errormessage.Text = "First name can only have letters";
                }
                else if (string.IsNullOrEmpty(textBoxLastName.Text))
                {
                    errormessage.Text = "Please Enter the Last Name";
                    textBoxLastName.Focus();
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxLastName.Text, "^[a-zA-Z]+$"))
                {
                    errormessage.Text = "Last name can only have letters";
                }
                else if (textBoxEmail.Text.Length == 0)
                {
                    errormessage.Text = "Please Enter an email.";
                    textBoxEmail.Focus();
                }
                else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Please Enter a valid email.";
                    textBoxEmail.Select(0, textBoxEmail.Text.Length);
                    textBoxEmail.Focus();
                }
                else if(textBoxEmail.Text == usermail)
                {
                    errormessage.Text = "This email already exists!";
                    textBoxEmail.Focus();
                }
                else if (passwordBox1.Password.Length == 0)
                {
                    errormessage.Text = "Please Enter password.";
                    passwordBox1.Focus();
                }
                else if (passwordBoxConfirm.Password.Length == 0)
                {
                    errormessage.Text = "Please Enter the 'Confirmed Password'.";
                    passwordBoxConfirm.Focus();
                }
                else if (passwordBox1.Password != passwordBoxConfirm.Password)
                {
                    errormessage.Text = "Passwords does not match!.";
                    passwordBoxConfirm.Focus();
                }
                else if (string.IsNullOrEmpty(textBoxAddress.Text))
                {
                    errormessage.Text = "Please Enter the Address";
                    textBoxAddress.Focus();
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxAddress.Text, "^[a-zA-Z]+$"))
                {
                    errormessage.Text = "Address can only have letters";
                    textBoxAddress.Focus();
                }
                else if (chk_eng.IsChecked == false && chk_history.IsChecked == false && chk_science.IsChecked == false && chk_ICT.IsChecked == false && chk_math.IsChecked == false)
                {
                    errormessage.Text = "You must Select at Least One Subject";
                }
                else
                {
                    string firstname = textBoxFirstName.Text;
                    string lastname = textBoxLastName.Text;
                    string email = textBoxEmail.Text;
                    string password = passwordBox1.Password;
                    string address = textBoxAddress.Text;

                    using (SqlConnection cn = GetConnection())
                    {
                        errormessage.Text = "";
                        cn.Open();
                        string query = "Insert into Registration_stu (FirstName,LastName,Email,Password,Address,eng,math,science,ICT,history) values('" + firstname + "','" + lastname + "','" + email + "','" + password + "','" + address + "','" + eng + "','" + math + "','" + science + "','" + ict + "','" + history + "')";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.CommandType = CommandType.Text;
                        int i = cmd.ExecuteNonQuery();
                        if (i == 1)
                        {
                            MessageBox.Show("You have Registered successfully!","INFO",MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                        else if (i == 0)
                        {
                            MessageBox.Show("Could not Register");
                        }
                        cn.Close();
                        Reset();
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
    }
}