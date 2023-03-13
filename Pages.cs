using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamWPF_by_NN_
{
    public class Pages
    {
        private static dbconnection dbconnection;
        private static ProductPage productPage;
        private static Menu menuPage;
        private static ProductList productList;
        private static AutorizationPage autorizationPage;
        private static ProductEdit productEdit;
        public static dbconnection dbconn
        {
            get
            {
                if (dbconnection == null)
                {
                    dbconnection = new dbconnection();
                }
                return dbconnection;
            }
            set { dbconnection = value; }
        }
        public static ProductPage Product
        {
            get 
            {
                if (productPage == null)
                {
                    productPage = new ProductPage(dbconn);
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
                    productList = new ProductList(dbconn);
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
                    autorizationPage = new AutorizationPage(dbconn);
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
                    productEdit = new ProductEdit(dbconn);
                }
                return productEdit;
            }
        }
    }
}