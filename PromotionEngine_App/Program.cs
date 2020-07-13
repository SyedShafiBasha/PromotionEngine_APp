using System;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Promotion> listPromotions = new List<Promotion>();
            Console.WriteLine("You want to Add new pormotion? (Y/N)");
            string addPromotion = Console.ReadLine().ToUpper();
            if (addPromotion.Equals("Y"))
            {
                Console.WriteLine("Please enter admin Username? Username : Admin & Password : Admin");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter Password");
                string password = Console.ReadLine();
                if (userName.ToUpper() == "ADMIN" && password == "Admin")
                {
                    Console.WriteLine("How many new promotion you want to Add? (Example 2)");
                    int newPromotion = int.Parse(Console.ReadLine());
                    for (int i = 0; i < newPromotion; i++)
                    {
                        //Console.WriteLine("New promotion for Combined product? (Y/N)");
                        //if (Console.ReadLine().ToUpper().Equals("Y"))
                        //{
                        // Combined Promo product logic will come here
                        //}
                        //else
                        //{

                        //}
                        Console.WriteLine("Please add the new promotion product,unit,price with comma separate values : Example (a,5,200)? Not handled null condition and all");
                        string[] product = Console.ReadLine().Split(',');
                        if (product.Length == 3)
                        {
                            Dictionary<String, int> d1 = new Dictionary<String, int>();
                            d1.Add(product[0].ToUpper(), int.Parse(product[1]));
                            Promotion promotion = new Promotion(1, d1, int.Parse(product[2]));
                            listPromotions.Add(promotion);
                        }
                        else
                        {

                        }
                    }
                    listPromotions = Promotion.AddNewProductPromotion(listPromotions);
                    OrderProcess(listPromotions);
                }
                else
                {
                    Console.WriteLine("Invalid Username & Password");
                }

            }
            else
            {
                listPromotions = Promotion.DefaultProducPromotiont();
                OrderProcess(listPromotions);
            }
            Console.ReadLine();
        }


        public static void OrderProcess(List<Promotion> listPromotions)
        {
            Order order = null;
            List<Product> listProducts = new List<Product>();
            Product product = null;
            Console.WriteLine("Please enter number of items for orders");
            int totalOrder = 0;
            string userOrder = Console.ReadLine();
            while (!int.TryParse(userOrder, out totalOrder))
            {
                Console.WriteLine("You entered an invalid number");
                Console.WriteLine("Please enter total number of orders");
                userOrder = Console.ReadLine();
            }
            for (int i = 0; i < totalOrder; i++)
            {

                Console.WriteLine("Enter the type of product:A,B,C or D");
                product = new Product(Console.ReadLine().ToUpper());
                while (!Constant.ProductName.Contains(product.Id))
                {
                    Console.WriteLine("You entered an invalid product name");
                    Console.WriteLine("Enter the type of product:A,B,C or D");
                    product = new Product(Console.ReadLine().ToUpper());
                }
                listProducts.Add(product);
            }
            order = new Order(1, listProducts);

            List<int> promoprices = listPromotions.Select(promo => Promotion.GetTotalPrice(order, promo)).ToList();
            int totalPrice = promoprices.Sum();
            Console.WriteLine("Totla price of product {0}", totalPrice);
        }
    }
}
