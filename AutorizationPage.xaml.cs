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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage(dbconnection dbconnection)
        {
            InitializeComponent();
            string login = tbLogin.Text.Trim();
            string password = tbPassword.Text.Trim();
            if (login.Length == 0)
            {
                if (password.Length == 0)
                {
                
                }
                else MessageBox.Show("Введите логин");
            }
                else MessageBox.Show("Введите пароль");                    
        }

        private void Next(object sender, RoutedEventArgs e)
        {
            // User user = dbconnection.User.Where(user => user.UserLogin == login && user.UserPassword == password).FirstOrDefault();
            // if (user == null)
            // {
            //     MessageBox.Show("Неверный логин/пароль);
            //     CaptchaBlock.Visibility - Visibility.Visible;
            //     isCaptchaRequired = true;
            //     GenerateCaptcha();
            //     return;
            // }
            
        }
    }
}
