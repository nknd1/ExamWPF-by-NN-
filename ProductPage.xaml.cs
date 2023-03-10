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
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        dbconnection dbconn;
        public ProductCategory ProductCategory { get; set; }
        public ProductPage(dbconnection dbconnection)
        {
            InitializeComponent();
            ProductCategory = new ProductCategory();
            dbconn = dbconnection;
            DataContext = this;
            ProductBlock.DataContext = new ProductCategory();

            Binding binding = new Binding();
            binding.Source = dbconnection.ProductCategory.ToList();
            cbCategory.DisplayMemberPath = "Name";
            cbCategory.SetBinding(ComboBox.ItemsSourceProperty, binding);
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            Product product = ProductBlock.DataContext as Product;
            product.Name = tbCategoryName.Text.Trim();
            product.Provider = tbProvider.Text.Trim();
            product.Unit = tbUnitOfMeasurement.Text.Trim();
            product.Description = tbDescription.Text.Trim();
            if (product.Name.Length == 0 ) 
            {
                MessageBox.Show("Введите название товара");
                return;
            }
            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Категория не выбрана");
                return;
            }
            if (product.Provider.Length == 0)
            {
                MessageBox.Show("Укажите поставщика");
                return;
            }
            dbconn.Product.Add(product);
            dbconn.SaveChanges();
            MessageBox.Show("Product добавлен");
            ProductBlock.DataContext = new Product();  
        }

        private void SelectImageAndAdd(object sender, RoutedEventArgs e)
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
                ImageBlockk.Source = bitmap;
            }
        }

        private void BackToMenu(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}






       