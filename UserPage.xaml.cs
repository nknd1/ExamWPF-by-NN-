﻿using System;
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
        public User user;
        public Role role;
        
        
        
        
        
        public UserPage(conntodb dbconnection)
        {
            InitializeComponent();
            this.dbconn = dbconnection;
        }
     
        private void AddPhoto(object sender, RoutedEventArgs e)
        {

        }
    }
}
