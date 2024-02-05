using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Products.xaml
    /// </summary>
    public partial class Products : Page
    {
        public Products()
        {
            InitializeComponent();
            ctlg.ItemsSource = MainWindow.mycontext.Product.ToList();
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ctlg.ItemsSource = MainWindow.mycontext.Product.Where(item => item.Name == Search.Text || item.Name.Contains(Search.Text)
                || item.Aroma == Search.Text || item.Aroma.Contains(Search.Text)).ToList();
            }
            catch
            {

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (ctlg.SelectedItem != null)
            {
                _ = MainWindow.mycontext.Basket.Add(new Basket() { id_client = UserData.id, id_product = (ctlg.SelectedItem as Product).id, Status = "В корзине" });
                _ = MainWindow.mycontext.SaveChanges();

            }
            else
            {
                _ = MessageBox.Show("Сначала выберите товар!");
            }
        }
    }
}
