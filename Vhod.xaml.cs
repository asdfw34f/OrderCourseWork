using System.Windows;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Vhod.xaml
    /// </summary>
    public partial class Vhod : Window
    {
        public Vhod()
        {
            InitializeComponent();
        }



        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            Parol parol = new Parol();
            parol.Show();
            Close();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult Result = MessageBox.Show("Закрыть приложение ?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (Result == MessageBoxResult.Yes)
            {
                Close();
            }

        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            Autoriz autoriz = new Autoriz();
            autoriz.Show();
            Close();



        }
    }
}
