
using KinderGarten.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KinderGarten.ViewModel
{
    public class AutorizationWindowViewModel : BaseViewModel
    {
        private string _password;
        private string _login;
       
        List<User> Users = new List<User>();
        public string Password
        {
            get => _password;
            set => SetPropertyChanged(ref _password, value, nameof(_password));
        }
        public string Login
        {
            get => _login;
            set => SetPropertyChanged(ref _login, value, nameof(_login));
        }
    public AutorizationWindowViewModel()
        {
            AutorizationCommand = new RelayCommand(o => enterbtn());
        }
        public ICommand AutorizationCommand { get; set; }

        public void enterbtn()
        {
            using (var context = new KinderGartenDbEntities())
            {
                var user = context.User.FirstOrDefault(e => e.Login == Login && e.Password == Password);

                if (user != null)
                {
                    View.MainWindow mainWindow = new View.MainWindow();
                    mainWindow.Show();
                    Application.Current.MainWindow.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Данные введенны неверно. Повторите попытку.");
                }
            }
        }
    }
}
