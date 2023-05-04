using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Detials.xaml
    /// </summary>
    public partial class Detials : Window
    {
        public Detials()
        {
            InitializeComponent();
        }
        Class_File c1 = new Class_File();
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool isDragging = false;

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update();
            update.TextBlockId2.Text = TextBlockId1.Text;
            update.Txt_bloc_ID.Text = TextBlockId1.Text;
            update.Show();
            Close();
        }

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
