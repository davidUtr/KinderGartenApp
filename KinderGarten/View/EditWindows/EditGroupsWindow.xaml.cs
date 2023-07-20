using KinderGarten.Model;
using KinderGarten.Model.Entity;
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

namespace KinderGarten.View.EditWindows
{
    /// <summary>
    /// Логика взаимодействия для EditGroupsWindow.xaml
    /// </summary>
    public partial class EditGroupsWindow : Window
    {
        public EditGroupsWindow(Model.Entity.Groups groups)
        {
            InitializeComponent();
            LoadTeachers();
            DataContext = groups;
        }

        public void LoadTeachers()
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var teacher = dbAccess.GetTeachers();
            FirstBox.ItemsSource = teacher;
            LastBox.ItemsSource = teacher;
        }
        private void createEducator_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            try
            {
                if (DataContext is Model.Entity.Groups children)
                {
                    if (string.IsNullOrEmpty(children.Name))
                    {
                        MessageBox.Show("Заполните все данные!");
                    }
                    else
                    {
                        dbAccess.UpdateGroup(children);
                        MessageBox.Show("Данные успешно сохранены!");
                        this.Close();
                    }
                }
            }
            catch { MessageBox.Show("Произошла ошибка! Введите все данные правильно!"); }
        
    }

        private void ExitImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
