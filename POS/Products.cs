using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS
{
    public class Products
    {
        private int ProductID;
        private string ProductName;
        private int Price;
        private int StockCount;
        private int CategoryID;

        public Products(int productID, string productName, int price, int stockCount, int categoryID)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
            StockCount = stockCount;
            CategoryID = categoryID;

        }

        public int Product_ID
        {
            get { return this.ProductID; }
            set { this.ProductID = value; }
        }
        public string Product_Name
        {
            get { return this.ProductName; }
            set { this.ProductName = value; }
        }
        public int Price1
        {
            get { return this.Price; }
            set { this.ProductID = value; }
        }

        public int Stock_Count
        {
            get { return this.StockCount; }
            set { this.StockCount = value; }
        }

        public int Catagory_ID
        {
            get { return this.CategoryID; }
            set { this.CategoryID = value; }
        }
    }
}
