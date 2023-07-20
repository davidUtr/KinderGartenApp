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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
namespace KinderGarten.View
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void ExitImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void SupportImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("KinderGartenSupport.chm");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Visible;
            PasswordBox.Visibility = Visibility.Hidden;
            Checked.Content = "Показать пароль";
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordText.Visibility = Visibility.Hidden;
            PasswordBox.Visibility = Visibility.Visible;
            PasswordBox.Password = PasswordText.Text;
            Checked.Content = "Показать пароль";
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordText.Text = PasswordBox.Password;
        }

        private void backWindow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

            this.DragMove();

            }
            catch { }
        }

        private void ExitImage_MouseEnter(object sender, MouseEventArgs e)
        {
            ExitImage.Opacity = 0.5;
        }

        private void ExitImage_MouseLeave(object sender, MouseEventArgs e)
        {
            ExitImage.Opacity = 0.3;
        }

        private void SupportImage_MouseEnter(object sender, MouseEventArgs e)
        {
            SupportImage.Opacity = 0.5;
        }

        private void SupportImage_MouseLeave(object sender, MouseEventArgs e)
        {
            SupportImage.Opacity = 0.3;
        }

        private void minimizedBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void minimizedBtn_MouseEnter(object sender, MouseEventArgs e)
        {
            minimizedBtn.Opacity = 0.5;
        }

        private void minimizedBtn_MouseLeave(object sender, MouseEventArgs e)
        {
            minimizedBtn.Opacity = 0.3;
        }

        private void SupportImage_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Process.Start("KinderGartenSupport.chm");
        }
    }
}
