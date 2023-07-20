using KinderGarten.Model;
using KinderGarten.Model.Entity;
using KinderGarten.View.AddWindows;
using KinderGarten.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для EditEducatorWindow.xaml
    /// </summary>
    public partial class EditEducatorWindow : Window
    {

        private Teachers _teacher;
        public EditEducatorWindow(Teachers teacher)
        {
            InitializeComponent();
            _teacher = teacher;
            DataContext = _teacher;
            PhoneText.Mask = "+9(999) 999 99 99";


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

        private void Text_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = SurnameText.Text;
            string text2 = NameText.Text;
            bool containsSpecialChars = text.Any(c => !Char.IsLetterOrDigit(c));
            bool containsNumbers = text.Any(c => Char.IsDigit(c));
            bool containsSpecialChars1 = text2.Any(c => !Char.IsLetterOrDigit(c));
            bool containsNumbers1 = text2.Any(c => Char.IsDigit(c));
            if (containsSpecialChars || containsNumbers)
            {
                MessageBox.Show("Специальные символы и числа запрещены!");
                SurnameText.Text = "";

            }
            if (containsSpecialChars1 || containsNumbers1)
            {
                MessageBox.Show("Специальные символы и числа запрещены!");
                NameText.Text = "";
            }
        }



        private void Text_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }


        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Images (.png, .jpg, .jpeg)|*.png;*.jpg;*.jpeg";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                string newFilename = System.IO.Path.GetFileNameWithoutExtension(dlg.FileName);
                string extension = System.IO.Path.GetExtension(dlg.FileName);
                string savePath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images", newFilename + extension);
                System.IO.Directory.CreateDirectory(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Images"));
                if (System.IO.File.Exists(savePath))
                {
                    MessageBox.Show("Фотография с таким названием уже существует. Выберите другую фотографию или переименуйте старую.");
                }
                else
                {

                    System.IO.File.Copy(dlg.FileName, savePath);
                    string dbPath =  newFilename + extension;
                    var teacher = (Teachers)DataContext;
                    teacher.PhotoTeachers = dbPath;
                    dbAccess.UpdateTeacherPhoto(teacher);
                    TeacherImage.Source = new BitmapImage(new Uri(savePath));
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_teacher != null && MessageBox.Show("Вы уверены, что хотите удалить этого учителя?", "Удаление учителя", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var db = new KinderGartenDbEntities();
                var dbAccess = new KinderGartenDbAccess(db);

                int teacherID = _teacher.ID;

                // проверяем, есть ли у учителя связанные записи расписания или группы
                var schedules = dbAccess.GetSchedules().Where(s => s.TeacherID == teacherID).ToList();
                var groups = dbAccess.GetGroups().Where(g => g.Teachers1Id == teacherID).ToList();

                if (schedules.Count > 0 || groups.Count > 0)
                {
                    MessageBox.Show("Данный воспитатель связан с группой или расписанием. Выберите замену");
                    SelectTeacherDialog dialog = new SelectTeacherDialog(dbAccess.GetTeachers());
                    bool? result = dialog.ShowDialog();
                    if (result.HasValue && result.Value && dialog.SelectedTeacher != null)
                    {
                        Teachers newTeacher = dialog.SelectedTeacher;

                        foreach (var schedule in schedules)
                        {
                            schedule.TeacherID = newTeacher.ID;
                            dbAccess.UpdateSchedule(schedule);
                        }

                        foreach (var group in groups)
                        {
                            group.Teachers1Id = newTeacher.ID;
                            dbAccess.UpdateGroup(group);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                dbAccess.RemoveTeacher(teacherID);



                db.Dispose();

                // закрываем окно редактирования информации
                this.Close();
            }
        }

        private void EditEducator_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            try
            {
                if (DataContext is Teachers _teacher)
                {
                    if (string.IsNullOrEmpty(_teacher.Name) || string.IsNullOrEmpty(_teacher.Surname) || string.IsNullOrEmpty(_teacher.NumberPhone) || string.IsNullOrEmpty(_teacher.NumberPasport) || string.IsNullOrEmpty(_teacher.SerialPasport) || string.IsNullOrEmpty(_teacher.Address) || string.IsNullOrEmpty(_teacher.Salary) || !_teacher.HireDate.HasValue)
                    {
                        MessageBox.Show("Пожалуйста, заполните все данные!");
                    }
                    else
                    {
                        dbAccess.UpdateTeachers(_teacher);
                        MessageBox.Show("Данные успешно сохранены!");
                        this.Close();
                    }
                }
            }
            catch { MessageBox.Show("Произошла ошибка! Повторите попытку позже"); }
        }
    }
}