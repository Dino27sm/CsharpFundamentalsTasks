using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.OrdersM2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ProductsInfo> productList = new List<ProductsInfo>();
            ProductsInfo currentProduct;
            string[] inpText = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            while(inpText[0] != "buy")
            {
                currentProduct = new ProductsInfo(inpText[0],
                    decimal.Parse(inpText[1]), int.Parse(inpText[2]));
                productList.Add(currentProduct);
                inpText = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            for (int i = 0; i < productList.Count; i++)
            {
                for (int k = i+1; k < productList.Count; k++)
                {
                    if (productList[i].ProductName == productList[k].ProductName)
                    {
                        productList[i].ProductQuantity += productList[k].ProductQuantity;
                        productList[i].ProductPrice = productList[k].ProductPrice;
                        productList.RemoveAt(k);
                    }
                }
            }
            for (int i = 0; i < productList.Count; i++)
            {
                Console.WriteLine($"{productList[i].ProductName} -> " +
                    $"{productList[i].ProductPrice * productList[i].ProductQuantity:F2}");
            }
        }
    }
    class ProductsInfo
    {
        public ProductsInfo(string name, decimal price, int quantity)
        {
            this.ProductName = name;
            this.ProductPrice = price;
            this.ProductQuantity = quantity;
        }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
    }
}
