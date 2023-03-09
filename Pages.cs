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
                if(menuPage == null)
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
    }
}