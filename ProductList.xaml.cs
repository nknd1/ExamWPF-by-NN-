using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для ProductList.xaml
    /// </summary>
    public class SortItem
    {
        public string Name { get; set; }
        public SortDescription sort { get; set; }
    }
    public partial class ProductList : Page
    {
        dbconnection dbconnection;
        public List<SortItem> SortLists { get; set; }
        public SortItem SelectedSortItem { get; set; }
        
        public SortItem SelectedSortProductCategory { get; set; }
        public ProductList(dbconnection dbconnection)
        {
            InitializeComponent();
            this.dbconnection = dbconnection;
            Binding binding = new Binding();
            binding.Source = dbconnection.Product.ToList();
            ProductView.SetBinding(ItemsControl.ItemsSourceProperty, binding);

            SortLists = new List<SortItem>()
            {
                new SortItem()
                {
                    Name = "По возрастанию(Цена)",
                    sort = new SortDescription("Cost",ListSortDirection.Ascending)
                },
                new SortItem()
                {
                    Name = "По убыванию(Цена)",
                    sort = new SortDescription("Cost", ListSortDirection.Descending)
                }
            };
            DataContext = this;
        }
        private void ApplySort()
        {
            var view = CollectionViewSource.GetDefaultView(ProductView.ItemsSource);
            if (view == null || SelectedSortItem == null) return;
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(SelectedSortItem.sort);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplySort();
        }
        private void Find(string search)
        {
            search = search.ToLower();

            var view = CollectionViewSource.GetDefaultView(ProductView.ItemsSource);
            if (view == null) return;

            if (search.Length == 0)
            {
                view.Filter= null;
            }
            else
            {
                view.Filter = new Predicate<object>((object o) =>
                {
                    Product product = o as Product;
                    if (product == null) return false;
                    return product.Name.ToLower().IndexOf(search) != -1;
                });
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                Find(textBox.Text);
            }
        }
        private void ProductView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = ProductView.SelectedItem as Product;
            if (selectedProduct != null)
            Pages.Edit.SetProduct(selectedProduct);
            NavigationService.Navigate(Pages.Edit);
            return;
        }
        public void ReloadProducts()
        {
            Binding binding = new Binding();
            binding.Source = dbconnection.Product.ToList();
           // ProductList.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }
    }
}
