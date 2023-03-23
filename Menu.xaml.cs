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
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {     
        public Menu()
        {
            InitializeComponent();
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Product);     
        }

        private void ViewProduct(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.List);
        }

        private void GoToAddUser(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.Users);
        }
    }
}
