using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;


namespace Индивидуальное_предпринимательство_по_производство_мыла
{
    /// <summary>
    /// Логика взаимодействия для Dobav.xaml
    /// </summary>
    public partial class Dobav : Page
    {
        public Dobav()
        {
            InitializeComponent();

        }

        private readonly OpenFileDialog fileDialog = new OpenFileDialog()
        {
            CheckFileExists = true,
            CheckPathExists = true,
            FilterIndex = 4,
            Filter = "JPG|*.jpg|JPEG|*.jpeg|PNG|*.png|Все файлы|*.*"
        };
        private string[] mas = new string[20];
        private int nomer;
        private string fill;
        private string rasp;
        private string FOTOpr;

        private void Add_Product(object sender, RoutedEventArgs e)
        {
            try
            {
                Product product = new Product()
                {
                    Name = NameCB.Text,
                    Aroma = AromaCB.Text,
                    Color = ColorCB.Text,
                    Weight = WeightTB.Text,
                    Compound = CompoundTB.Text,
                    Image = FOTOpr,
                    Price = Convert.ToInt32(PriceTB.Text),
                    Count_Saled = 0
                };



                if (fileDialog.SafeFileName != "")
                {
                    string filePath = System.IO.Path.Combine($"{AppDomain.CurrentDomain.BaseDirectory}\\Soap\\", fileDialog.SafeFileName);
                    if (!File.Exists(filePath))
                    {
                        File.Copy(fill, rasp, true);
                    }
                }
                _ = MainWindow.mycontext.Product.Add(product);
                _ = MainWindow.mycontext.SaveChanges();
                _ = MessageBox.Show("Товар добавлен!", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                _ = MessageBox.Show("Вы внесли не все данные о товаре!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fileDialog.ShowDialog().Value == true)
                {
                    fill = fileDialog.FileName;
                    Img.Source = new BitmapImage(new Uri(fill));
                    mas = fill.Split(new char[] { '\\' });
                    nomer = mas.Length;
                    rasp = $"{AppDomain.CurrentDomain.BaseDirectory}\\Soap\\{mas[nomer - 1]}";
                    FOTOpr = $"Soap\\{mas[nomer - 1]}";
                }
            }
            catch
            {
                _ = MessageBox.Show("Ошибка");
            }
        }

        private void Delet_Click(object sender, RoutedEventArgs e)
        {
            Img.Source = null;
        }

        private void PriceTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _ = Convert.ToInt32(PriceTB.Text);
            }
            catch
            {
                PriceTB.Text = string.Empty;
            }

        }
    }
}
