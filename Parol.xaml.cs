using System.Windows;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Parol.xaml
    /// </summary>
    public partial class Parol : Window
    {
        public Parol()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Log.Text;
            string password = Pass.Password;

            if (login == "admin" && password == "5665")
            {
                Admin admin = new Admin();
                admin.Show();
                Close();
            }
            else
            {
                _ = MessageBox.Show("Неверный логин или пароль!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Вы действительно хотите вернуться назад ?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Vhod vhod = new Vhod();
                vhod.Show();
                Close();
            }
        }
    }
}
