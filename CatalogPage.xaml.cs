using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для CatalogPage.xaml
    /// </summary>
    public partial class CatalogPage : Page
    {
        public CatalogPage()
        {
            InitializeComponent();

            DataContext = MainWindow.mycontext.Client.ToList();
            CatalogView.ItemsSource = MainWindow.mycontext.Product.ToList();
            pricebox.SelectedIndex = 0;
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CatalogView.ItemsSource = MainWindow.mycontext.Product.Where(item => item.Name == Search.Text || item.Name.Contains(Search.Text)
                    || item.Aroma == Search.Text || item.Aroma.Contains(Search.Text)).ToList();
            }
            catch
            {

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действильно хотите удалить товар?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Product CurrentApplications = CatalogView.SelectedItem as Product;
                    _ = MainWindow.mycontext.Product.Remove(CurrentApplications);
                    _ = MainWindow.mycontext.SaveChanges();
                    CatalogView.ItemsSource = MainWindow.mycontext.Product.ToList();
                }
                catch
                {
                    _ = MessageBox.Show("Вы не выбрали товар!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                CatalogView.ItemsSource = MainWindow.mycontext.Product.Where(item => item.Name == Search.Text || item.Name.Contains(Search.Text)).ToList();
            }
            catch
            {

            }
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            _ = CatalogView.Items.SortDescriptions.Remove(new SortDescription("Count_Saled", ListSortDirection.Descending));
            CatalogView.Items.SortDescriptions.Add(
                   new SortDescription("Count_Saled", ListSortDirection.Ascending));



        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            _ = CatalogView.Items.SortDescriptions.Remove(CatalogView.Items.SortDescriptions.Last());
            CatalogView.Items.SortDescriptions.Add(
                new SortDescription("Count_Saled", ListSortDirection.Descending));
        }
    }
}