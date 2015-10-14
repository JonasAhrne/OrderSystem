using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem
{
    public class Controller
    {
        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        Utility myUtility = new Utility();
        public Controller()
        {

        }

        public void CreateCustomer(string[] CustomerData)
        {
            dataAccessLayer.CreateCustomer(CustomerData);
        }
        
        public void CreateProduct(string[] ProductData)
        {
            dataAccessLayer.CreateProduct(ProductData);
        }
        
        public void CreateOrder(string[] OrderData)
        {
            dataAccessLayer.CreateOrder(OrderData);
        }

        public void CreateOrderrow(string[] OrderrowData)
        {
            dataAccessLayer.CreateOrderrow(OrderrowData);
        }

        public int GetOrderNbr()
        {
           return dataAccessLayer.GetOrderNbr();
        }
        
        public void DeleteCustomer(string Ssn)
        {
            dataAccessLayer.DeleteCustomer(Ssn);
        }
        
        public void DeleteProduct(string ProductNbr)
        {
            dataAccessLayer.DeleteProduct(ProductNbr);
        }
        
        public void DeleteOrder(string OrderNbr)
        {
            dataAccessLayer.DeleteOrder(OrderNbr);
        }

        public void UpdateCustomer(string[] CustomerData)
        {
            dataAccessLayer.UpdateCustomer(CustomerData);
        }
        public void UpdateProduct(string[] ProductData)
        {
            dataAccessLayer.UpdateProduct(ProductData);
        }
        
        public void SearchProduct(string ProductSearch, DataSet Ds)
            {
            dataAccessLayer.SearchProduct(ProductSearch, Ds);
        }
        
        public void SearchCustomer(string CustomerSearch, DataSet Ds)
        {
            dataAccessLayer.SearchCustomer(CustomerSearch, Ds);
        }

        public void SearchOrder(string OrderSearch, DataSet Ds)
        {
            dataAccessLayer.SearchOrder(OrderSearch, Ds);
        }

        public void SearchOrderrow(string OrderNbr, DataSet Ds)
        {
            dataAccessLayer.SearchOrderrow(OrderNbr, Ds);
        }

        public void PopulateCustomer(string CustomerSsn, DataSet Ds)
        {
            dataAccessLayer.PopulateCustomer(CustomerSsn, Ds);
        }

        public void PopulateProduct(string ProductNbr, DataSet Ds)
        {
            dataAccessLayer.PopulateProduct(ProductNbr, Ds);
        }
        //Handle exception
        public string HandleException(Exception ex)
    {
        return myUtility.HandleException(ex);
    }
    }
}
