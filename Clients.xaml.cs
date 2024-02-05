using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Clients.xaml
    /// </summary>
    public partial class Clients : Page
    {
        public Clients()
        {
            InitializeComponent();
            DataContext = MainWindow.mycontext.Client.ToList();
            ClientsView.ItemsSource = MainWindow.mycontext.Client.ToList();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ClientsView.ItemsSource = MainWindow.mycontext.Client.Where(item => item.FIO == SearchTbClients.Text || item.FIO.Contains(SearchTbClients.Text)).ToList();
            }
            catch
            {

            }
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действильно хотите удалить Клиента?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Client CurrentApplications = ClientsView.SelectedItem as Client;
                    _ = MainWindow.mycontext.Client.Remove(CurrentApplications);
                    _ = MainWindow.mycontext.SaveChanges();
                    ClientsView.ItemsSource = MainWindow.mycontext.Client.ToList();
                }
                catch
                {
                    _ = MessageBox.Show("Вы не выбрали клиента!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
