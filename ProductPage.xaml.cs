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
        public ProductCategory ProductCategory { get; set; }
        public ProductPage(dbconnection dbconnection)
        {
            InitializeComponent();
            ProductCategory = new ProductCategory();
            dbconnection = dbconnection;
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
            if (product.Manufacturer.Length == 0)
            {
                MessageBox.Show("Укажите проихводителя");
                return;
            }

        }

    }
}






       