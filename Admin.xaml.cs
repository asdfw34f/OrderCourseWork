using System.Windows;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Clients_Click(object sender, RoutedEventArgs e)
        {
            _ = myFrame.Navigate(new Clients());
        }

        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = myFrame.Navigate(new Dobav());
        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Вы действительно хотите вернуться на главную страницу ?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Vhod vhod = new Vhod();
                vhod.Show();
                Close();
            }
        }


        private void Catalog_Click(object sender, RoutedEventArgs e)
        {
            _ = myFrame.Navigate(new CatalogPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _ = myFrame.Navigate(new Orders());
        }
    }
}
