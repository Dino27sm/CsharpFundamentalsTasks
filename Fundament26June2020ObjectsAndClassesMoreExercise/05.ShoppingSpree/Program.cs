using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] personsAndMoney = Console.ReadLine()
                .Split(new string[] { ";", "; " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] productsAndPrice = Console.ReadLine()
                .Split(new string[] { ";", "; " }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            List<Person> personList = new List<Person>();
            List<Product> productList = new List<Product>();
            for (int i = 0; i < personsAndMoney.Length; i++)
            {
                string[] personMoney = personsAndMoney[i].Split("=").ToArray();
                string namePerson = personMoney[0];
                double moneyPerson = double.Parse(personMoney[1]);
                Person personObject = new Person(namePerson, moneyPerson);
                personList.Add(personObject);
            }
            for (int i = 0; i < productsAndPrice.Length; i++)
            {
                string[] productPrice = productsAndPrice[i].Split("=").ToArray();
                string product = productPrice[0];
                double price = double.Parse(productPrice[1]);
                Product productObject = new Product(product, price);
                productList.Add(productObject);
            }
            string shopings = "";
            while ((shopings = Console.ReadLine()) != "END")
            {
                string[] personBought = shopings.Split().ToArray();
                string person = personBought[0];
                string product = personBought[1];
                Person fidName = personList.Find(x => x.PersonName == person);
                Product findProduct = productList.Find(x => x.ProductName == product);
                if (fidName.PersonMoney - findProduct.ProductPrice >= 0)
                {
                    fidName.PersonMoney -= findProduct.ProductPrice;
                    fidName.PersonBag.Add(product);
                    Console.WriteLine($"{person} bought {product}");
                }
                else Console.WriteLine($"{person} can't afford {product}");
            }
            foreach (Person item in personList)
            {
                if (item.PersonBag.Count < 1) Console.WriteLine($"{item.PersonName} - Nothing bought");
                else item.PrintPersonBagList();
            }
        }
    }
    public class Person
    {
        public string PersonName { get; set; }
        public double PersonMoney { get; set; }
        public List<string> PersonBag { get; set; }
        public Person(string name, double money)
        {
            this.PersonBag = new List<string>();
            this.PersonName = name;
            this.PersonMoney = money;
        }
        public void PrintPersonBagList()
        {
            Console.Write($"{this.PersonName} - ");
            Console.WriteLine(string.Join(", ", this.PersonBag));
        }
    }

    public class Product
    {
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public Product(string name, double price)
        {
            this.ProductName = name;
            this.ProductPrice = price;
        }
    }
}
