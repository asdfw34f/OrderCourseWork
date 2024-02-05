using System.Text.RegularExpressions;
using System.Windows;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();

        }

        private bool CheckString(string txt)
        {
            return !string.IsNullOrEmpty(txt);
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string t = PhoneBox.Text;


            string pattern = @"\+7\d{10}";

            if (!Regex.IsMatch(t, pattern))
            {
                PhoneBox.Text = "";
            }

            if (CheckString(FIOBox.Text) && CheckString(EmailBox.Text) && CheckString(AddressBox.Text) && CheckString(PhoneBox.Text) && CheckString(DayBox.Text) && pass1Box.Password.Equals(pass2Box.Password))
            {
                Client client = new Client()
                {
                    FIO = FIOBox.Text,
                    Email = EmailBox.Text,
                    Phone_Number = PhoneBox.Text,
                    Birthday = DayBox.SelectedDate,
                    Password = pass1Box.Password,
                    Adress = AddressBox.Text
                };

                _ = MainWindow.mycontext.Client.Add(client);
                _ = MainWindow.mycontext.SaveChanges();

                if (MessageBox.Show(
                    "Регистрация прошла успешна!",
                    "Регистрация",
                    MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {

                    new Autoriz().Show();
                    Close();

                }
            }
            else
            {
                _ = MessageBox.Show(
                    "Заполните все поля!",
                    "Регистрация",
                    MessageBoxButton.OK, MessageBoxImage.Warning);

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new Autoriz().Show();
            Close();
        }

    }
}
