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
    /// Логика взаимодействия для EditParentsWindow.xaml
    /// </summary>
    public partial class EditParentsWindow : Window
    {
        private Parents _parents;
        public EditParentsWindow(Parents parents)
        {
            InitializeComponent();
            _parents = parents;
            DataContext = _parents;
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

        private void createEducator_Click(object sender, RoutedEventArgs e)
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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (_parents != null && MessageBox.Show("Вы уверены, что хотите удалить информацию о родителе?", "Удаление данных", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                var db = new KinderGartenDbEntities();
                var dbAccess = new KinderGartenDbAccess(db);

                // получаем идентификатор учителя
                int teacherID = _parents.ID;

                // получаем список записей расписания и групп, связанных с данным учителем
                var schedules = dbAccess.GetChildren().Where(s => s.FatherId == teacherID || s.MomId == teacherID).ToList();


                // если есть связанные записи, показываем диалог выбора другого учителя
                if (schedules.Count > 0)
                {
                    MessageBox.Show("Невозможно удалить информацию о родителе, так как он связан с ребёнком: ");

                }
                else

                    // удаляем учителя из таблицы Teachers
                    dbAccess.RemoveParents(teacherID);

                // обновляем DataGrid
               

                // освобождаем ресурсы контекста базы данных
                db.Dispose();
                this.Close();
            }


        }

        private void EditEducator_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            try
            {
                if (DataContext is Parents _parents)
                {
                    if (string.IsNullOrEmpty(_parents.Name) || string.IsNullOrEmpty(_parents.Surname) || string.IsNullOrEmpty(_parents.NumberPhone) || string.IsNullOrEmpty(_parents.NumberPasport) || string.IsNullOrEmpty(_parents.SerialPasport) || string.IsNullOrEmpty(_parents.Address))
                    {
                        MessageBox.Show("Пожалуйста, заполните все данные!");
                    }
                    else
                    {
                        dbAccess.UpdateParents(_parents);
                        MessageBox.Show("Данные успешно сохранены!");
                        this.Close();
                    }
                }
            }
            catch { MessageBox.Show("Произошла ошибка! Повторите попытку позже"); }
        }

        private void SurnameText_TextChanged(object sender, TextChangedEventArgs e)
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

        private void SerialText_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }
    }
}