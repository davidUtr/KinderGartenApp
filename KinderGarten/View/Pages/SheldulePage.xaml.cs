using KinderGarten.Model.Entity;
using KinderGarten.View.AddWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using KinderGarten.Model;
using System.Printing;
using KinderGarten.View.EditWindows;

namespace KinderGarten.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SheldulePage.xaml
    /// </summary>
    public partial class SheldulePage : Page
    {
        private Model.Entity.Groups selectedGroup;
        public SheldulePage()
        {
            InitializeComponent();
            using (var context = new KinderGartenDbEntities())
            {
                scheduleTable = new ObservableCollection<Schedule>(context.Schedule.ToList());
            }
            ScheduleDG.ItemsSource= scheduleTable;
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            SearchGroups.ItemsSource = dbAccess.GetGroup();
            FilterDataGrid();
        }

        public ObservableCollection<Schedule> scheduleTable { get; set; } = new ObservableCollection<Schedule>();
        public ObservableCollection<Schedule> ScheduleTable { get { return scheduleTable; } }


        private void FilterDataGrid()
        {
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            var equipment = dbAccess.GetSchedules();

            // Фильтр поставщиков
            if (selectedGroup != null && selectedGroup.ID != -1)
            {
                equipment = equipment.Where(x => x.GroupID == selectedGroup.ID).ToList();
            }


            ScheduleDG.ItemsSource = equipment;
        }


        private void searchDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = searchDate.SelectedDate; // Получаем выбранную пользователем дату
            ICollectionView view = CollectionViewSource.GetDefaultView(ScheduleDG.ItemsSource); // Получаем представление коллекции
            if (selectedDate.HasValue) // Если пользователь выбрал дату
            {
                view.Filter = item =>
                {
                    Schedule schedule = item as Schedule; // Получаем текущий объект Schedule
                    return schedule.Date.Date == selectedDate.Value.Date; // Фильтруем записи по дате
                };
            }
            else // Если пользователь не выбрал дату
            {
                view.Filter = null; // Отображаем все занятия
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            ScheduleAdd add = new ScheduleAdd();
            add.ShowDialog();
            using (var context = new KinderGartenDbEntities())
            {
                scheduleTable = new ObservableCollection<Schedule>(context.Schedule.ToList());
            }
            ScheduleDG.ItemsSource = scheduleTable;
        }

        private void deleteSchedule_Click(object sender, RoutedEventArgs e)
        {

            Schedule schedule = ScheduleDG.SelectedItem as Schedule;
            if (schedule != null && MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление записи", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var db = new KinderGartenDbEntities();
                var dbAccess = new KinderGartenDbAccess(db);

                // получаем идентификатор записи
                int ID = schedule.ID;

                // удаление записи из таблицы Schedule
                dbAccess.RemoveSchedule(ID);

                // обновляем DataGrid
                ScheduleDG.ItemsSource = dbAccess.GetSchedules();
                

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
                    printDialog.PrintDocument(((IDocumentPaginatorSource)ScheduleDG.Items.SortDescriptions).DocumentPaginator, "Расписание"); 
                } 
            }
                }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Schedule schedule = (sender as Button).DataContext as Schedule; // получение объекта Schedule из DataContext кнопки
            ScheduleEdit editWindow = new ScheduleEdit(schedule); // создание окна редактирования и передача объекта Schedule в конструктор
            editWindow.ShowDialog(); // открытие окна редактирования в модальном режиме
            using (var context = new KinderGartenDbEntities())
            {
                scheduleTable = new ObservableCollection<Schedule>(context.Schedule.ToList());
            }
            ScheduleDG.ItemsSource = scheduleTable;
        }

        private void ScheduleDG_LoadingRow(object sender, DataGridRowEventArgs e)
        {
           

        }

        private void SearchGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedGroup = SearchGroups.SelectedItem as Model.Entity.Groups;
            FilterDataGrid();
        }
    }

        
    }
