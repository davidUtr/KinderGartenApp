using KinderGarten.Model;
using KinderGarten.Model.Entity;
using KinderGarten.ViewModel;
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

namespace KinderGarten.View
{
    /// <summary>
    /// Логика взаимодействия для EditChildrenWindow.xaml
    /// </summary>
    public partial class EditChildrenWindow : Window
    {
        public EditChildrenWindow(Children children)
        {
            InitializeComponent();
            DataContext = children;
            LoadParents();
            LoadGroup();
        }


        private void LoadGroup()
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var group = dbAccess.GetGroups();
            GroupBox.ItemsSource = group;
        }
        private void LoadParents()
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var parents = dbAccess.GetParents();
            FatherBox.ItemsSource = parents;
            MotherBox.ItemsSource = parents;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


        }
        private void ExitImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
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

        private void createEducator_Copy_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                this.DragMove();

            }
            catch { }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            try
            {
                if (DataContext is Children children)
                {
                    if (string.IsNullOrEmpty(children.Name) || string.IsNullOrEmpty(children.Surname))
                    {
                        MessageBox.Show("Заполните все данные!");
                    }
                    else
                    {
                        dbAccess.UpdateChildren(children);
                        MessageBox.Show("Данные успешно сохранены!");
                        this.Close();
                    }
                }
            }
            catch { MessageBox.Show("Произошла ошибка! Введите все данные правильно!"); }
        }
 
    }

}
    

