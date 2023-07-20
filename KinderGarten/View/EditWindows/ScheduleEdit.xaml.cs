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
    /// Логика взаимодействия для ScheduleEdit.xaml
    /// </summary>
    public partial class ScheduleEdit : Window
    {
        public ScheduleEdit(Schedule schedule)
        {
            
            InitializeComponent();
            DataContext = schedule;
            LoadTeachers();
            LoadGroups();

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

        private void LoadGroups()
        {
            
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var groups = dbAccess.GetGroups();
            comboBoxGroup.ItemsSource = groups;
        }
        private void LoadTeachers()
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var teachers = dbAccess.GetTeachers();
            comboBoxTeacher.ItemsSource = teachers;
        }

        private void createSchedule_Click(object sender, RoutedEventArgs e)
        {

            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            if (DataContext is Schedule schedule)
            {
                if (dbAccess.IsScheduleConflicting(schedule))
                {
                    MessageBox.Show("Данный учитель или группа уже имеют занятие в это время. Пожалуйста, выберите другие дату или время.");
                    return;
                }

                dbAccess.UpdateSchedule(schedule); // сохраняем объект Schedule в БД
            }

            Close();
        }


    }

}

