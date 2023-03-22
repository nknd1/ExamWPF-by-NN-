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
        private dbconnection dbconnection;
        private bool isCaptchaRequired = false;
        private string captchaChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwyz1234567890";
        private string captchaCode = "";
        private Random random;
        
        public AutorizationPage(dbconnection dbconnection)
        {
            InitializeComponent();
            this.dbconnection = dbconnection;
            random = new Random();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isCaptchaRequired)
            {
                if (captchaCode != tbCaptcha.Text)
                {
                    MessageBox.Show("Неверный код");
                    return;
                }
                isCaptchaRequired = false;
                CaptchaBlock.Visibility = Visibility.Collapsed;       
            }
            string login = tbLogin.Text.Trim();
            if (login.Length == 0)
            {
                MessageBox.Show("Введите логин");
            }
            string password = tbPassword.Text.Trim();
            if (password.Length == 0)
            {
                MessageBox.Show("Введите пароль");
            }

            User user = dbconnection.User.Where(User => User.UserLogin == login && User.UserPassword == password).FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Неверный логин/пароль");
                return;
            }
            NavigationService.Navigate(Pages.MenuPage);       
        }
        private void GenerationCaptcha()
        {
            captchaCode = "";
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(captchaChars.Length);
                captchaCode += captchaChars[index];
            }
            lCaptcha.Content = captchaCode;
        }
    }
}
        
       
       
        // User user = dbconnection.User.Where(user => user.UserLogin == login && user.UserPassword == password).FirstOrDefault();
        // if (user == null)
        // {
        //     MessageBox.Show("Неверный логин/пароль);
        //     CaptchaBlock.Visibility - Visibility.Visible;
        //     isCaptchaRequired = true;
        //     GenerateCaptcha();
        //     return;
        // }

        

