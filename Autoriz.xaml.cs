using System.Linq;
using System.Windows;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Window
    {
        public Autoriz()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Vhod vhod = new Vhod();
            vhod.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = Pass.Password;
            string login = EmailBox.Text;

            if (!string.IsNullOrEmpty(pass) && !string.IsNullOrEmpty(login))
            {
                Client user = MainWindow.mycontext.Client.FirstOrDefault(u => u.Email == login && u.Password == pass);
                if (user != null)
                {

                    UserData.id = user.id;

                    Zakaz zakaz = new Zakaz();
                    zakaz.Show();
                    Close();
                }
                else
                {
                    _ = MessageBox.Show(
                        "Неправильно набран логин или пароль",
                        "Ошибка авторизации",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            Close();
        }
    }
}
