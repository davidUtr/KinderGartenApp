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
    /// Логика взаимодействия для SelectTeacherDialog.xaml
    /// </summary>
    public partial class SelectTeacherDialog : Window
    {
        public List<Teachers> Teachers { get; set; }
        public Teachers SelectedTeacher { get; private set; }

        public SelectTeacherDialog(List<Teachers> teachers)
        {
            InitializeComponent();
            Teachers = teachers;
            teachersList.ItemsSource = Teachers;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            SelectedTeacher = teachersList.SelectedItem as Teachers;
            if (SelectedTeacher != null)
            {
                DialogResult = true;
                Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
