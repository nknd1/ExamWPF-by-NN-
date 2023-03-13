using System;
using System.Collections.Generic;
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
        private dbconnection dbconn;
        public ProductEdit(dbconnection dbconnection)
        {
            InitializeComponent();
            this.dbconn = dbconnection;
            DataContext= this;
            ProductBlock.DataContext = new Product();
            cbCategory.DisplayMemberPath = "Name";
            
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
    }
}
