using KinderGarten.Model;
using KinderGarten.Model.Entity;
using KinderGarten.View.EditWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        public GroupsPage()
        {
            InitializeComponent();
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            GroupDG.ItemsSource = dbAccess.GetGroups();

        }
      

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddGroupWindow add = new AddGroupWindow();
            add.ShowDialog();
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
            GroupDG.ItemsSource = dbAccess.GetGroups();
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (GroupDG.Items.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog(); if (printDialog.ShowDialog() == true)
                { // Установка имени документа и размеров страницы для печати
                    printDialog.PrintTicket.PageMediaSize = new PageMediaSize(PageMediaSizeName.ISOA4);
                    printDialog.PrintTicket.PageOrientation = PageOrientation.Portrait;
                    printDialog.PrintDocument(((IDocumentPaginatorSource)GroupDG.Items.SortDescriptions).DocumentPaginator, "Группы");
                }
            }
        
    }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            Model.Entity.Groups groups = (sender as Button).DataContext as Model.Entity.Groups; // получение объекта Schedule из DataContext кнопки
            EditGroupsWindow editWindow = new EditGroupsWindow(groups); // создание окна редактирования и передача объекта Schedule в конструктор
            editWindow.ShowDialog(); // открытие окна редактирования в модальном режиме
            var db = new KinderGartenDbEntities();
            var dbAccess = new KinderGartenDbAccess(db);
        }

        private void deleteSchedule_Click(object sender, RoutedEventArgs e)
        {
            Model.Entity.Groups teacher = GroupDG.SelectedItem as Model.Entity.Groups;
            if (teacher != null && MessageBox.Show("Вы уверены, что хотите удалить информацию о родителе?", "Удаление данных", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                var db = new KinderGartenDbEntities();
                var dbAccess = new KinderGartenDbAccess(db);

                // получаем идентификатор учителя
                int teacherID = teacher.ID;

                // получаем список записей расписания и групп, связанных с данным учителем
                var children = dbAccess.GetChildren().Where(s => s.GroupID == teacherID).ToList();
              
                

                // если есть связанные записи, показываем диалог выбора другого учителя
                if (children.Count >0 )
                {
                    MessageBox.Show("Невозможно удалить информацию о группе, так как имеются связи с расписанием или детьми ");

                }
                else

                    // удаляем учителя из таблицы Teachers
                    dbAccess.RemoveGroup(teacherID);

                // обновляем DataGrid
                GroupDG.ItemsSource = dbAccess.GetGroups();

                // освобождаем ресурсы контекста базы данных
                db.Dispose();
            }

        }
    }
}
