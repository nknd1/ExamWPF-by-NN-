using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamWPF_by_NN_
{
    /// <summary>
    /// Логика взаимодействия для ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Page
    {
        private conntodb dbconn;
        public ProductEdit(conntodb dbconnection)
        {
            InitializeComponent();
            this.dbconn = dbconnection;
            DataContext = this;
            ProductBlock.DataContext = new Product();
            cbCategory.DisplayMemberPath = "Name";
            Binding binding = new Binding();
            binding.Source = dbconnection.ProductCategory.ToList();
            cbCategory.DisplayMemberPath = "Name";
            cbCategory.SetBinding(ComboBox.ItemsSourceProperty, binding);
        }
        public void SetProduct(Product product)
        {
            ProductBlock.DataContext = product;
        }
        private void SaveProduct(object sender, RoutedEventArgs e)
        {
            dbconn.SaveChanges();
            if (NavigationService.CanGoBack)
            {
                NavigationService.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product product = ProductBlock.DataContext as Product;
            if (product == null)
                return;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Файлы изображений|*.jpg;*.jpeg;*.png;";
            fileDialog.Multiselect = false;
            if (fileDialog.ShowDialog() == true)
            {
                Stream fileStream = fileDialog.OpenFile();
                product.Photo = new byte[fileStream.Length];
                fileStream.Read(product.Photo, 0, (int)fileStream.Length);

                fileStream.Seek(0, SeekOrigin.Begin);
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = fileStream;
                bitmap.EndInit();
                ImageBlock.Source = bitmap;
            }
        }

        private void DeleteClick_Click(object sender, RoutedEventArgs e)
        {
            Product product = ProductBlock.DataContext as Product;
            if (product == null) return;
            dbconn.Product.Remove(product);
            MessageBox.Show("Товар удалён");
            dbconn.SaveChanges();

            Pages.List.ReloadProducts();
        }

        private void StopEdit(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack(); 
        }
    }
}
