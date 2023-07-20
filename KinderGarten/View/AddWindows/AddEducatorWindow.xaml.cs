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
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
            PhoneText.Mask = "+9(999) 999 99 99";
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
        private string _teacherPhotoPath;
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".png";
            dlg.Filter = "Images (.png, .jpg, .jpeg)|*.png;*.jpg;*.jpeg";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                TeacherImage.Source = new BitmapImage(new Uri(dlg.FileName));
                _teacherPhotoPath = dlg.FileName;
            
        
    }
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

        private void AddEducator_Click(object sender, RoutedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            if (string.IsNullOrEmpty(NameText.Text) || string.IsNullOrEmpty(SurnameText.Text) || string.IsNullOrEmpty(SalaryText.Text) || string.IsNullOrEmpty(AddressText.Text) || string.IsNullOrEmpty(PhoneText.Text) || string.IsNullOrEmpty(SerialText.Text) || string.IsNullOrEmpty(NumberPasText.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все данные!");
            }
            else if (string.IsNullOrEmpty(_teacherPhotoPath))
            {
                MessageBox.Show("Пожалуйста, выберите фотографию!");
            }
            else
            {
                Teachers newTeacher = new Teachers
                {
                    Name = NameText.Text,
                    Surname = SurnameText.Text,
                    Salary = SalaryText.Text,
                    Address = AddressText.Text,
                    HireDate = hireDate.SelectedDate ?? DateTime.MinValue,
                    NumberPhone = PhoneText.Text,
                    SerialPasport = SerialText.Text,
                    NumberPasport = NumberPasText.Text,
                };
                dbAccess.AddTeachers(newTeacher, _teacherPhotoPath);
                MessageBox.Show("Преподаватель успешно добавлен в базу данных!");
            }
        }

    } 
}
        
    

