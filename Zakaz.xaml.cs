using System.Windows;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    public partial class Zakaz : Window
    {

        public Zakaz()
        {
            InitializeComponent();

            _ = myFrame.Navigate(new Products());
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Vhod vhod = new Vhod();
            vhod.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _ = myFrame.Navigate(new Products());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _ = myFrame.Navigate(new BasketPage());
        }
    }
}