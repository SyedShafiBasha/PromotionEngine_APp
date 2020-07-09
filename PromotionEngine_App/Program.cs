using System;
using System.Collections.Generic;

namespace PromotionEngine_App
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please enter total number of orders");

            GetTotalOrderDetails(Console.ReadLine());

            Console.ReadLine();
        }

        public static void GetTotalOrderDetails(string userOrder)
        {
            IProductService productService = new ProductService();
            List<Product> products = new List<Product>();
            Product product = null;
            int totalOrder = 0;

            while (!int.TryParse(userOrder, out totalOrder))
            {
                Console.Clear();
                Console.WriteLine("You entered an invalid number");
                Console.WriteLine("Please enter total number of orders");
                userOrder = Console.ReadLine();
            }
            for (int i = 0; i < totalOrder; i++)
            {
                product = new Product();
                Console.WriteLine("Enter the type of product:A,B,C or D");
                product.Id = Console.ReadLine().ToUpper();
                productService.GetPriceByType(product);
                products.Add(product);
            }
            int totalPrice = productService.GetTotalProductPrice(products);
            Console.WriteLine("Totla price of product {0}", totalPrice);

        }
    }
}
