using System;
using System.Collections.Generic;
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
using KinderGarten.View;
using KinderGarten.View.Pages;

namespace KinderGarten.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new SheldulePage();
          
        }
        private void ExitImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SupportImage_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EducatorBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new EducatorPage());
        }

        private void ParentsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ParentsPage());
        }

        private void ChildrenBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ChildrenPage());
        }

        private void GroupsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new GroupsPage());
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            minimizedBtn.Opacity = 0.5;
        }

        private void Rectangle_MouseLeave(object sender, MouseEventArgs e)
        {
            minimizedBtn.Opacity = 0.3;
        }

        private void ExitImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitImage.Opacity = 0.5;
        }

        private void ExitImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitImage.Opacity = 0.3;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                this.DragMove();

            }
            catch { }
        }

        private void SheduleBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SheldulePage());
        }
    }
}
