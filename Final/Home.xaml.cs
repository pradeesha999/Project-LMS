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
using System.Net;
using System.Xml.Linq;
using System.IO;

namespace Final
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            
        }
        string id;
        Class_File c1 = new Class_File();
        string eng, math1, science1, ict1, history1;
        string fname, lname, mail, pass, address , email;
        string eng_vis, math_vis,science_vis,history_vis,ict_vis;

        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=.;Initial Catalog=Final;Integrated Security=True");
        }
        public void SubData()
        {
            using (SqlConnection cn = GetConnection())
            {
                Detials detils = new Detials();
                id = TextBlockId.Text;
                cn.Open();
                string query = "Select * from Registration_stu where studentId = '" + id + "'";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    detils.TextBlockId1.Text = dataSet.Tables[0].Rows[0]["studentId"].ToString();
                    eng = dataSet.Tables[0].Rows[0]["eng"].ToString();
                    math1 = dataSet.Tables[0].Rows[0]["math"].ToString();
                    science1 = dataSet.Tables[0].Rows[0]["science"].ToString();
                    ict1 = dataSet.Tables[0].Rows[0]["ICT"].ToString();
                    history1 = dataSet.Tables[0].Rows[0]["history"].ToString();
                    email = dataSet.Tables[0].Rows[0]["Email"].ToString();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                cn.Close();
            }
        }
        private void btn_eng_Click(object sender, RoutedEventArgs e)
        {
            SubData();
            if (eng == "1")
            {
                English english = new English();
                english.Txt_SenderEmail.Text = email;
                english.Show();
            }
            else
            {
                MessageBox.Show("You have not selected this subject");
            }
        }

        private void btn_math_Click(object sender, RoutedEventArgs e)
        {
            SubData();
            if (math1 == "1")
            {
                Maths math = new Maths();
                math.Txt_SenderEmail.Text = email;
                math.Show();
                
            }
            else
            {
                MessageBox.Show("You have not selected this subject");
            }
            
        }

        private void btn_science_Click(object sender, RoutedEventArgs e)
        {
            SubData();
            if (science1 == "1")
            {
                Science science = new Science();
                science.Txt_SenderEmail.Text= email;
                science.Show();
                
            }
            else
            {
                MessageBox.Show("You have not selected this subject");
            }
            
        }

        private void btn_history_Click(object sender, RoutedEventArgs e)
        {
            SubData();
            if (history1 == "1")
            {
                History history = new History();
                history.Txt_SenderEmail.Text= email;
                history.Show();
            }
            else
            {
                MessageBox.Show("You have not selected this subject");
            }
            
        }

        private void btn_ICT_Click(object sender, RoutedEventArgs e)
        {
            SubData();
            if (ict1 == "1")
            {
                ICT iCT = new ICT();
                iCT.Txt_SenderEmail.Text = email;
                iCT.Show();
            }
            else
            {
                MessageBox.Show("You have not selected this subject");
            }
            
        }
        private void btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            Close();
        }
        

        private void Btn_User_Details_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    Detials detils = new Detials();
                    id = TextBlockId.Text;
                    cn.Open();
                    string query = "Select * from Registration_stu where studentId = '" + id + "'";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.CommandType = CommandType.Text;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = cmd;
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        detils.TextBlockId1.Text = id;
                        detils.Txt_bloc_ID.Text = id;
                        fname = dataSet.Tables[0].Rows[0]["FirstName"].ToString();
                        detils.Txt_bloc_fname.Text = fname;
                        lname = dataSet.Tables[0].Rows[0]["LastName"].ToString();
                        detils.Txt_bloc_lname.Text = lname;
                        mail = dataSet.Tables[0].Rows[0]["Email"].ToString();
                        detils.Txt_bloc_mail.Text = mail;
                        pass = dataSet.Tables[0].Rows[0]["Password"].ToString();
                        detils.Txt_bloc_pass.Text = pass;
                        address = dataSet.Tables[0].Rows[0]["Address"].ToString();
                        detils.Txt_bloc_address.Text = address;
                        eng_vis = dataSet.Tables[0].Rows[0]["eng"].ToString();
                        math_vis = dataSet.Tables[0].Rows[0]["math"].ToString();
                        science_vis = dataSet.Tables[0].Rows[0]["science"].ToString();
                        ict_vis = dataSet.Tables[0].Rows[0]["ICT"].ToString();
                        history_vis = dataSet.Tables[0].Rows[0]["history"].ToString();
                        if (eng_vis == "1")
                        {
                            detils.Txt_eng.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            detils.Txt_eng.Visibility = Visibility.Collapsed;
                        }
                        if (math_vis == "1")
                        {
                            detils.Txt_math.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            detils.Txt_math.Visibility = Visibility.Collapsed;
                        }
                        if (science_vis == "1")
                        {
                            detils.Txt_science.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            detils.Txt_science.Visibility = Visibility.Collapsed;
                        }
                        if (history_vis == "1")
                        {
                            detils.Txt_history.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            detils.Txt_history.Visibility = Visibility.Collapsed;
                        }
                        if (ict_vis == "1")
                        {
                            detils.Txt_ict.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            detils.Txt_ict.Visibility = Visibility.Collapsed;
                        }
                        detils.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    cn.Close();
                }                
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Invalid Operation Exception");
            } 
        }
        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Do you wish to delete your account details?", "WARNING", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                if (result == MessageBoxResult.Yes)
                {
                    string query = "Delete From Registration_stu Where studentId = '" + TextBlockId.Text + "'";
                    int i = c1.Insert(query);
                    if (i == 1)
                    {
                        MessageBox.Show("Your account has been deleted", "INFO", MessageBoxButton.OK, MessageBoxImage.Information);
                        Close();
                        this.Close();
                        Login l1 = new Login();
                        l1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                }
                else
                {

                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Database Error");
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
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
