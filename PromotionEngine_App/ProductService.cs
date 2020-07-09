using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine_App
{
    public class ProductService : IProductService
    {
        public void GetPriceByType(Product product)
        {
            switch (product.Id)
            {
                case "A":
                    product.Price = Constant.ProductA;
                    break;
                case "B":
                    product.Price = Constant.ProductB;
                    break;
                case "C":
                    product.Price = Constant.ProductC;
                    break;
                case "D":
                    product.Price = Constant.ProductD;
                    break;
            }
        }

        public int GetTotalProductPrice(List<Product> products)
        {
            if (products != null && products.Count > 0)
            {
                int listOfAProduct = products.Where(x => x.Id != null && x.Id == "A").Count();
                int listOfBProduct = products.Where(x => x.Id != null && x.Id == "B").Count();
                int listOfCProduct = products.Where(x => x.Id != null && x.Id == "C").Count();
                int listOfDProduct = products.Where(x => x.Id != null && x.Id == "D").Count();
                return GetTotalAProductPrice(listOfAProduct) + GetTotalBProductPrice(listOfBProduct) + GetTotalCDProductPrice(listOfCProduct, listOfDProduct);
            }
            return 0;
        }

        public int GetTotalAProductPrice(int listOfAProduct)
        {
            return (listOfAProduct / 3) * Constant.DiscountPriceOfProductA + (listOfAProduct % 3 * Constant.ProductA);
        }

        public int GetTotalBProductPrice(int listOfBProduct)
        {
            return (listOfBProduct / 2) * Constant.DiscountPriceOfProductB + (listOfBProduct % 2 * Constant.ProductB);
        }

        public int GetTotalCDProductPrice(int listOfCProduct, int listOfDProduct)
        {
            if (listOfCProduct == listOfDProduct)
                return listOfCProduct * Constant.DiscountPriceOfProductCD;
            else if (listOfCProduct != 0 || listOfDProduct != 0)
                return (listOfCProduct * Constant.ProductC) + (listOfDProduct * Constant.ProductD);
            return 0;
        }
    }
}
