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
    /// Логика взаимодействия для UserPage.xaml
    /// </summary>
    public partial class UserPage : Page
    {
        private conntodb dbconn;
        public User user { get; set; }
        public Role role { get; set; }
 
        public UserPage(conntodb dbconnection)
        {
            InitializeComponent();
            role = new Role();
            this.dbconn = dbconnection;
            DataContext = this;

            UserBlock.DataContext = new User();
            cbRole.DisplayMemberPath = "RoleName";

            Binding binding = new Binding();
            binding.Source = dbconnection.ProductCategory.ToList();
            cbRole.DisplayMemberPath = "RoleName";
            cbRole.SetBinding(ComboBox.ItemsSourceProperty, binding);

        }
     
        private void AddPhoto(object sender, RoutedEventArgs e)
        {

        }

        private void toUserList(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.ListUser);
        }
    }
}
