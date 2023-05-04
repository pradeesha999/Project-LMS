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
    public partial class Teacher_log : Window
    {
        public Teacher_log()
        {
            InitializeComponent();
        }
        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (teachEmail.Text.Length == 0)
                {
                    errormessage.Text = "Enter an email.";
                    teachEmail.Focus();
                }
                else if (!Regex.IsMatch(teachEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
                {
                    errormessage.Text = "Enter a valid email.";
                    teachEmail.Select(0, teachEmail.Text.Length);
                    teachEmail.Focus();
                }
                else
                {
                    string email = teachEmail.Text;
                    string password = teachpass.Password;
                    using (SqlConnection cn = GetConnection())
                    {
                        cn.Open();
                        string query = "Select * from Registration_teach where Email='" + email + "'  and password='" + password + "'";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter adapter1 = new SqlDataAdapter();
                        adapter1.SelectCommand = cmd;
                        DataSet dataSet1 = new DataSet();
                        adapter1.Fill(dataSet1);
                        if (dataSet1.Tables[0].Rows.Count > 0)
                        {
                            string username = dataSet1.Tables[0].Rows[0]["FirstName"].ToString() + " " + dataSet1.Tables[0].Rows[0]["LastName"].ToString();
                            string subject = dataSet1.Tables[0].Rows[0]["Subject"].ToString();
                            if (subject == "English")
                            {
                                English_tec english_Tec = new English_tec();
                                english_Tec.TextBlockName.Text = username;
                                english_Tec.Show();
                                Close();
                            }
                            else if (subject == "Maths")
                            {
                                Math_tec Math_Tec = new Math_tec();
                                Math_Tec.TextBlockName.Text = username;
                                Math_Tec.Show();
                                Close();
                            }
                            else if (subject == "Science")
                            {
                                Science_tec science_Tec = new Science_tec();
                                science_Tec.TextBlockName.Text = username;
                                science_Tec.Show();
                                Close();
                            }
                            else if (subject == "History")
                            {
                                History_tec history_Tec = new History_tec();
                                history_Tec.TextBlockName.Text = username;
                                history_Tec.Show();
                                Close();
                            }
                            else if (subject == "ICT")
                            {
                                ICT_tec iCT_Tec = new ICT_tec();
                                iCT_Tec.TextBlockName.Text = username;
                                iCT_Tec.Show();
                                Close();
                            }
                        }
                        else
                        {
                            errormessage.Text = "Sorry! Please enter existing emailid/password.";
                        }
                        cn.Close();
                    }                    
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }

        }

        private void Student_log_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
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
    }
}