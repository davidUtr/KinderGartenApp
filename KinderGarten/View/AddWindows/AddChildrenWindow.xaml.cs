using KinderGarten.Model.Entity;
using KinderGarten.Model;
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
    /// Логика взаимодействия для AddChildrenWindow.xaml
    /// </summary>
    public partial class AddChildrenWindow : Window
    {
        public AddChildrenWindow()
        {
            InitializeComponent();
            LoadGroup();
            LoadParents();
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
            this.DragMove();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            if (string.IsNullOrEmpty(Name.Text) || string.IsNullOrEmpty(Surname.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все данные!");
            }

            else
            {
                Children newParents = new Children
                {
                
                    Name = Name.Text,
                    Surname = Surname.Text,
                    FatherId = (int)FatherBox.SelectedValue,
                    MomId = (int)MotherBox.SelectedValue,
                    GroupID = (int)GroupBox.SelectedValue,
                    DateOfBirth = dateOfBirths.SelectedDate ?? DateTime.MinValue
                };
                dbAccess.AddChildren(newParents);
                MessageBox.Show("Ребёнок успешно добавлен в базу данных!");
                this.Close();
            }
        }
    }

}