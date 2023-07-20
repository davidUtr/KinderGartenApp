using KinderGarten.Model;
using KinderGarten.Model.Entity;
using KinderGarten.View.AddWindows;
using KinderGarten.View.EditWindows;
using KinderGarten.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KinderGarten.View
{
    /// <summary>
    /// Логика взаимодействия для EducatorPage.xaml
    /// </summary>
    public partial class EducatorPage : Page
    {
      
        public EducatorPage()
        {
            InitializeComponent();
            using (var context = new KinderGartenDbEntities())
            {
                scheduleTable = new ObservableCollection<Teachers>(context.Teachers.ToList());
            }
            ScheduleDG.ItemsSource = scheduleTable;
            LWTeachers.ItemsSource = scheduleTable;

        }

        public ObservableCollection<Teachers> scheduleTable { get; set; } = new ObservableCollection<Teachers>();
        public ObservableCollection<Teachers> ScheduleTable { get { return scheduleTable; } }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchText.Text.ToLower(); // Получаем текст поиска в нижнем регистре
            ICollectionView view = CollectionViewSource.GetDefaultView(ScheduleDG.ItemsSource); // Получаем представление коллекции
            if (!string.IsNullOrEmpty(searchText)) // Если поисковая строка не пуста
            {
                view.Filter = item =>
                {
                    Teachers schedule = item as Teachers; // Получаем текущий объект Schedule
                    using (var context = new KinderGartenDbEntities()) // Создаем новый контекст базы данных
                    {
                        // Используем LINQ-запрос для поиска сотрудника по серии и номеру паспорта
                        var teacher = context.Teachers.FirstOrDefault(t => t.ID == schedule.ID && (t.SerialPasport.ToLower() + t.NumberPasport.ToLower()).Contains(searchText));
                        return teacher != null; // Возвращаем true, если найден сотрудник
                    }
                };
            }
            else // Если поисковая строка пуста
            {
                view.Filter = null; // Отображаем все занятия
            }
        }


        private void ScheduleDG_Loaded(object sender, RoutedEventArgs e)
        {
            SearchText.TextChanged += SearchText_TextChanged;
        }

       

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow add = new AddWindow();
            add.ShowDialog();
            using (var context = new KinderGartenDbEntities())
            {
                scheduleTable = new ObservableCollection<Teachers>(context.Teachers.ToList());
            }
            ScheduleDG.ItemsSource = scheduleTable;
            LWTeachers.ItemsSource = scheduleTable;
        }

        private void deleteTeacher_Click(object sender, RoutedEventArgs e)
        {
            Teachers teacher = ScheduleDG.SelectedItem as Teachers; 
            if (teacher != null && MessageBox.Show("Вы уверены, что хотите удалить этого учителя?", "Удаление учителя", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
               
                var db = new KinderGartenDbEntities(); 
                var dbAccess = new KinderGartenDbAccess(db);

                // получаем идентификатор учителя
                int teacherID = teacher.ID;

                // получаем список записей расписания и групп, связанных с данным учителем
                var schedules = dbAccess.GetSchedules().Where(s => s.TeacherID == teacherID).ToList();
                var groups = dbAccess.GetGroups().Where(g => g.Teachers1Id == teacherID).ToList();

                // если есть связанные записи, показываем диалог выбора другого учителя
                if (schedules.Count > 0 || groups.Count > 0)
                {
                    MessageBox.Show("Данный воспитатель связан с группой или расписанием. Выберите замену");
                    SelectTeacherDialog dialog = new SelectTeacherDialog(dbAccess.GetTeachers());
                    bool? result = dialog.ShowDialog();
                    if (result.HasValue && result.Value && dialog.SelectedTeacher != null)
                    {
                        Teachers newTeacher = dialog.SelectedTeacher;

                        // обновляем записи расписания с новым учителем
                        foreach (var schedule in schedules)
                        {
                            schedule.TeacherID = newTeacher.ID;
                            dbAccess.UpdateSchedule(schedule);
                            
                        }

                        // обновляем группы с новым учителем
                        foreach (var group in groups)
                        {
                            group.Teachers1Id = newTeacher.ID;
                            dbAccess.UpdateGroup(group);
                        }
                    }
                    else
                    {
                        // пользователь отменил выбор другого учителя, прерываем удаление
                        return;
                    }
                }

                // удаляем учителя из таблицы Teachers
                dbAccess.RemoveTeacher(teacherID);

                // обновляем DataGrid
                ScheduleDG.ItemsSource = dbAccess.GetTeachers();
                LWTeachers.ItemsSource = dbAccess.GetTeachers();

                // освобождаем ресурсы контекста базы данных
                db.Dispose();
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (ScheduleDG.Items.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog(); if (printDialog.ShowDialog() == true)
                { // Установка имени документа и размеров страницы для печати
                    printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
                    printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                    printDialog.PrintDocument(((IDocumentPaginatorSource)ScheduleDG.Items.SortDescriptions).DocumentPaginator, "Воспитатели");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Teachers teacher = (sender as Button).DataContext as Teachers; // получение объекта Schedule из DataContext кнопки
            EditEducatorWindow editWindow = new EditEducatorWindow(teacher); // создание окна редактирования и передача объекта Schedule в конструктор
            editWindow.ShowDialog(); // открытие окна редактирования в модальном режиме
            using (var context = new KinderGartenDbEntities())
            {
                scheduleTable = new ObservableCollection<Teachers>(context.Teachers.ToList());
            }
            ScheduleDG.ItemsSource = scheduleTable;
            LWTeachers.ItemsSource = scheduleTable;
        }

        private void ScheduleDG_LoadingRow(object sender, DataGridRowEventArgs e)
        {


        }

        private void LWTeachers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            if (LWTeachers.SelectedItem != null)
            {
                var selectedTeacher = (Teachers)LWTeachers.SelectedItem;
                var editWindow = new EditEducatorWindow(selectedTeacher);
                editWindow.ShowDialog();
                ScheduleDG.ItemsSource = dbAccess.GetTeachers();
                LWTeachers.ItemsSource = dbAccess.GetTeachers();
            }
        }
    }


}
