using KinderGarten.Model;
using KinderGarten.Model.Entity;
using KinderGarten.View.AddWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Printing;
using System.Security.Cryptography;
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
    /// Логика взаимодействия для ParentsPage.xaml
    /// </summary>
    public partial class ParentsPage : Page
    {
        Parents human = null;
        public ParentsPage()
        {
            InitializeComponent();
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            ParentsDG.ItemsSource = dbAccess.GetParents();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddParentsWindow add = new AddParentsWindow();
            add.ShowDialog();
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            ParentsDG.ItemsSource = dbAccess.GetParents();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Parents parents = (sender as Button).DataContext as Parents; // получение объекта Schedule из DataContext кнопки
            EditParentsWindow editWindow = new EditParentsWindow(parents); // создание окна редактирования и передача объекта Schedule в конструктор
            editWindow.ShowDialog(); // открытие окна редактирования в модальном режиме
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            ParentsDG.ItemsSource = dbAccess.GetParents();

        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchText.Text.ToLower(); // Получаем текст поиска в нижнем регистре
            ICollectionView view = CollectionViewSource.GetDefaultView(ParentsDG.ItemsSource); // Получаем представление коллекции
            if (!string.IsNullOrEmpty(searchText)) // Если поисковая строка не пуста
            {
                view.Filter = item =>
                {
                    Parents schedule = item as Parents; // Получаем текущий объект Schedule
                    using (var context = new KinderGartenDbEntities()) // Создаем новый контекст базы данных
                    {
                        // Используем LINQ-запрос для поиска сотрудника по серии и номеру паспорта
                        var teacher = context.Parents.FirstOrDefault(t => t.ID == schedule.ID && (t.SerialPasport.ToLower() + t.NumberPasport.ToLower()).Contains(searchText));
                        return teacher != null; // Возвращаем true, если найден сотрудник
                    }
                };
            }
            else // Если поисковая строка пуста
            {
                view.Filter = null; // Отображаем все занятия
            }
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (ParentsDG.Items.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog(); if (printDialog.ShowDialog() == true)
                { // Установка имени документа и размеров страницы для печати
                    printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
                    printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                    printDialog.PrintDocument(((IDocumentPaginatorSource)ParentsDG.Items.SortDescriptions).DocumentPaginator, "Родители");
                }
            }
        }

        private void deleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            Parents teacher = ParentsDG.SelectedItem as Parents;
            if (teacher != null && MessageBox.Show("Вы уверены, что хотите удалить информацию о родителе?", "Удаление данных", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                var db = new KinderGartenDbEntities();
                var dbAccess = new KinderGartenDbAccess(db);

                // получаем идентификатор учителя
                int teacherID = teacher.ID;

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
                ParentsDG.ItemsSource = dbAccess.GetParents();

                // освобождаем ресурсы контекста базы данных
                db.Dispose();
            }
  

    }

    private void ParentsDG_Loaded(object sender, RoutedEventArgs e)
        {
            SearchText.TextChanged += SearchText_TextChanged;
        }
    }
}

    

