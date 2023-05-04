using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.IO;

namespace Final
{
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        public Update()
        {
            InitializeComponent();
        }
        Class_File c1 = new Class_File();
        int eng = 0, math = 0, science = 0, history = 0, ict = 0;
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

        private void button3_Click(object sender, RoutedEventArgs e)
        {
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
            chk_eng1.IsChecked = false;
            chk_history1.IsChecked = false;
            chk_ICT1.IsChecked = false;
            chk_science1.IsChecked = false;
            chk_math1.IsChecked = false;
        }
        private void Chk_eng_Checked1(object sender, RoutedEventArgs e)
        {
            if (chk_eng1.IsChecked == true)
            {
                eng = 1;
            }

        }
        private void Chk_eng_Unchecked1(Object sender, RoutedEventArgs e)
        {
            if (chk_eng1.IsChecked == false)
            {
                eng = 0;
            }
        }
        private void Chk_history_Checked1(object sender, RoutedEventArgs e)
        {
            if (chk_history1.IsChecked == true)
            {
                history = 1;
            }
        }
        private void Chk_history_Unchecked1(object sender, RoutedEventArgs e)
        {
            if (chk_history1.IsChecked == false)
            {
                history = 0;
            }
        }
        private void Chk_science_Checked1(object sender, RoutedEventArgs e)
        {
            if (chk_science1.IsChecked == true)
            {
                science = 1;
            }
        }
        private void Chk_science_Unchecked1(object sender, RoutedEventArgs e)
        {
            if (chk_science1.IsChecked == false)
            {
                science = 0;
            }
        }
        private void Chk_ICT_Checked1(object sender, RoutedEventArgs e)
        {
            if (chk_ICT1.IsChecked == true)
            {
                ict = 1;
            }
        }
        private void Chk_ICT_Unchecked1(object sender, RoutedEventArgs e)
        {
            if (chk_ICT1.IsChecked == false)
            {
                ict = 0;
            }
        }
        private void Chk_math_Checked1(object sender, RoutedEventArgs e)
        {
            if (chk_math1.IsChecked == true)
            {
                math = 1;
            }
        }
        private void Chk_math_Unchecked1(object sender, RoutedEventArgs e)
        {
            if (chk_math1.IsChecked == false)
            {
                math = 0;
            }
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxFirstName.Text))
                {

                    errormessage.Text = "Please Enter the First Name.";
                    textBoxFirstName.Focus();

                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxFirstName.Text, "^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Invalid input. Please enter only letters.");
                }
                else if (string.IsNullOrEmpty(textBoxLastName.Text))
                {
                    errormessage.Text = "Please Enter the Last Name";
                    textBoxLastName.Focus();
                }
                else if (!System.Text.RegularExpressions.Regex.IsMatch(textBoxLastName.Text, "^[a-zA-Z]+$"))
                {
                    MessageBox.Show("Invalid input. Please enter only letters.");
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
                    errormessage.Text = "Confirm password must be same as password.";
                    passwordBoxConfirm.Focus();
                }
                else if (string.IsNullOrEmpty(textBoxAddress.Text))
                {
                    errormessage.Text = "Please Enter the Address";
                    textBoxAddress.Focus();
                }
                else if (chk_eng1.IsChecked == false && chk_history1.IsChecked == false && chk_science1.IsChecked == false && chk_ICT1.IsChecked == false && chk_math1.IsChecked == false)
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
                    string id = TextBlockId2.Text;
                    errormessage.Text = "";

                    string query = "UPDATE Registration_stu SET FirstName = '" + firstname + "', LastName = '" + lastname + "',Email = '" + email + "',Password = '" + password + "',Address = '" + address + "',eng = '" + eng + "',math = '" + math + "',science = '" + science + "',ICT = '" + ict + "',history = '" + history + "' where studentId = '" + id + "'";
                    int i = c1.Insert(query);
                    if (i == 1)
                    {
                        MessageBox.Show("Details Updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Could not Update Details");
                    }
                    Reset();
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
    }
}

