using KinderGarten.Model;
using KinderGarten.Model.Entity;
using KinderGarten.View.AddWindows;
using KinderGarten.View.EditWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Printing;
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
    /// Логика взаимодействия для ChildrenPage.xaml
    /// </summary>
    public partial class ChildrenPage : Page
    {
        public ChildrenPage()
        {
            InitializeComponent();
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            ChildrenDG.ItemsSource = dbAccess.GetChildren();
        }

        private void SearchText_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchText.Text.ToLower(); // Получаем текст поиска в нижнем регистре
            ICollectionView view = CollectionViewSource.GetDefaultView(ChildrenDG.ItemsSource); // Получаем представление коллекции
            if (!string.IsNullOrEmpty(searchText)) // Если поисковая строка не пуста
            {
                view.Filter = item =>
                {
                    Children schedule = item as Children; // Получаем текущий объект Schedule
                    using (var context = new KinderGartenDbEntities()) // Создаем новый контекст базы данных
                    {
                        // Используем LINQ-запрос для поиска сотрудника по серии и номеру паспорта
                        var teacher = context.Children.FirstOrDefault(t => t.ID == schedule.ID && (t.Name.ToLower() + t.Surname.ToLower()).Contains(searchText));
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
            if (ChildrenDG.Items.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog(); if (printDialog.ShowDialog() == true)
                { // Установка имени документа и размеров страницы для печати
                    printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
                    printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                    printDialog.PrintDocument(((IDocumentPaginatorSource)ChildrenDG.Items.SortDescriptions).DocumentPaginator, "Дети");
                }
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddChildrenWindow add = new AddChildrenWindow();
            add.ShowDialog();
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            ChildrenDG.ItemsSource = dbAccess.GetChildren();
        }

        private void ChildrenDG_Loaded(object sender, RoutedEventArgs e)
        {
            SearchText.TextChanged += SearchText_TextChanged;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Children children = (sender as Button).DataContext as Children; // получение объекта Schedule из DataContext кнопки
            EditChildrenWindow editWindow = new EditChildrenWindow(children); // создание окна редактирования и передача объекта Schedule в конструктор
            editWindow.ShowDialog(); // открытие окна редактирования в модальном режиме
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            ChildrenDG.ItemsSource = dbAccess.GetChildren();
        }

        private void deleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            Children schedule = ChildrenDG.SelectedItem as Children;
            if (schedule != null && MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление записи", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var db = new KinderGartenDbEntities();
                var dbAccess = new KinderGartenDbAccess(db);

                // получаем идентификатор записи
                int ID = schedule.ID;

                // удаление записи из таблицы Schedule
                dbAccess.RemoveChildren(ID);

                // обновляем DataGrid
                ChildrenDG.ItemsSource = dbAccess.GetChildren();


                // освобождаем ресурсы контекста базы данных
                db.Dispose();
            }
        }


    }
}
