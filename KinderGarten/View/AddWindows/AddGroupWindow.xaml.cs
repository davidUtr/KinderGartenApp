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

namespace KinderGarten.View
{
    /// <summary>
    /// Логика взаимодействия для AddGroupWindow.xaml
    /// </summary>
    public partial class AddGroupWindow : Window
    {
        public AddGroupWindow()
        {
            InitializeComponent();
            LoadTeachers();
        }
        public void LoadTeachers()
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var teacher = dbAccess.GetTeachers();
            FirstBox.ItemsSource = teacher;
            LastBox.ItemsSource = teacher;
        }

        private void ExitImage_MouseDown(object sender, MouseButtonEventArgs e)
        {

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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {

                this.DragMove();

            }
            catch { }
        }

        private void createEducator_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            if (string.IsNullOrEmpty(GroupName.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все данные!");
            }

            else
            {
                Model.Entity.Groups newParents = new Model.Entity.Groups
                {

                    Name = GroupName.Text,
                    AgeFrom = int.Parse(MinText.Text),
                    AgeTo = int.Parse(MaxText.Text),
                    Teachers1Id = (int)FirstBox.SelectedValue,
                    Teachers2Id = (int)LastBox.SelectedValue,
                    MaxCapacity = 1
                };
                dbAccess.AddGroup(newParents);
                MessageBox.Show("Группа успешно добавлена в базу данных!");
                this.Close();
            }
        }
    
    }

}
