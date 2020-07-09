using System;
using System.Collections.Generic;

namespace PromotionEngine_App
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductService productService = new ProductService();
            List<Product> products = new List<Product>();
            Console.WriteLine("Please enter total number of orders");
            Product product = null;
            int totalOrder = Convert.ToInt32(Console.ReadLine());
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
            Console.ReadLine();
        }
    }
}
