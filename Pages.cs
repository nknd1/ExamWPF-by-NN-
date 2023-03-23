using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPF_by_NN_
{
    public class Pages
    {
        private static conntodb conntodb;
        private static ProductPage productPage;
        private static Menu menuPage;
        private static ProductList productList;
        private static AutorizationPage autorizationPage;
        private static ProductEdit productEdit;
        private static UserPage userPage;
        private static ProductPageRole pageRole;
        private static User user;
        public static conntodb dbconnection
        {
            get
            {
                if (conntodb == null)
                {
                    conntodb = new conntodb();
                }
                return conntodb;
            }
            set { conntodb = value; }
        }
        public static ProductPage Product
        {
            get 
            {
                if (productPage == null)
                {
                    productPage = new ProductPage(dbconnection);
                }
                return productPage;
            }
        }
        public static Menu MenuPage
        {
            get
            {
                if (menuPage == null)
                {
                    menuPage = new Menu();
                }
                return menuPage;
            }
        }
        public static ProductList List
        {
            get
            {
                if (productList == null)
                {
                    productList = new ProductList(dbconnection);
                }
                return productList;
            }
        }
        public static AutorizationPage Autorization
        {
            get
            {
                if (autorizationPage == null)
                {
                    autorizationPage = new AutorizationPage(dbconnection);
                }
                return autorizationPage;
            }
        }
        public static ProductEdit Edit
        {
            get
            {
                if (productEdit == null)
                {
                    productEdit = new ProductEdit(dbconnection);
                }
                return productEdit;
            }
        }
        public static ProductPageRole ProductRole
        {
            get
            {
                if(pageRole == null)
                {
                    pageRole = new ProductPageRole(dbconnection);
                }
                return pageRole;
            }
        }
        public static UserPage Users
        {
            get
            {
                if (userPage == null)
                {
                    userPage = new UserPage(dbconnection);
                }
                return userPage;
            }
        }
    }
}