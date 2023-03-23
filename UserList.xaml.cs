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
    /// Логика взаимодействия для UserList.xaml
    /// </summary>
    public class SortItems
    {
        public string User { get; set; }
    }
    public partial class UserList : Page
    {
        conntodb dbconnection;

        public UserList(conntodb dbconnection)
        {       
            InitializeComponent();
            this.dbconnection = dbconnection;
            Binding binding = new Binding();
            binding.Source = dbconnection.Product.ToList();
            UserView.SetBinding(ItemsControl.ItemsSourceProperty, binding);
        }

        private void UserView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
