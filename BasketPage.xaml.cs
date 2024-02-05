using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Basket.xaml
    /// </summary>
    public partial class BasketPage : Page
    {
        private List<Basket> bas = MainWindow.mycontext.Basket.Where(b => b.Client.id == UserData.id && b.Status == "В корзине").ToList();

        public BasketPage()
        {
            InitializeComponent();

            if (bas.Count > 0)
            {
                basView.ItemsSource = bas;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Basket> myBas = MainWindow.mycontext.Basket.Where(w => w.id_client == UserData.id).ToList();
            foreach (Basket mb in myBas)
            {
                _ = MainWindow.mycontext.Basket.Remove(mb);
                _ = MainWindow.mycontext.SaveChanges();
            }
            UpdateBasket();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int price = (int)bas.Select(s => s.Product.Price).Sum();

            if (MessageBox.Show(
                $"Цена заказа: {price}\nОформить заказ?",
                "Оформление заказа",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {


                for (int i = 0; i < bas.Count; i++)
                {
                    bas[i].Status = "Заказ оформлен";
                    bas[i].Product.Count_Saled += 1;
                }

                MainWindow.mycontext.Basket.AddOrUpdate(bas.ToArray());
                _ = MainWindow.mycontext.SaveChanges();
                UpdateBasket();

            }
        }

        private void UpdateBasket()
        {
            bas = MainWindow.mycontext.Basket.Where(b => b.Client.id == UserData.id && b.Status == "В корзине").ToList();
            basView.ItemsSource = bas;
        }
    }
}
// daafgr@gmail.com
