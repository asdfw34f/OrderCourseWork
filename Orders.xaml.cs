using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Page
    {
        private List<Basket> context = MainWindow.mycontext.Basket.Where(b => b.Status != "В корзине").ToList();

        public Orders()
        {
            InitializeComponent();
            DataContext = context;
            OrdersView.ItemsSource = context;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Завершить заказ?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Basket CurrentItems = OrdersView.SelectedItem as Basket;
                    _ = MainWindow.mycontext.Basket.Remove(CurrentItems);
                    _ = MainWindow.mycontext.SaveChanges();
                    context = MainWindow.mycontext.Basket.Where(b => b.Status != "В корзине").ToList();
                    OrdersView.ItemsSource = context;
                }
                catch
                {
                    _ = MessageBox.Show("Выберите заказ!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
