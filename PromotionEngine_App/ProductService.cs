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
                int countOfAProduct = products.Where(x => x.Id != null && x.Id == "A").Count();
                int countOfBProduct = products.Where(x => x.Id != null && x.Id == "B").Count();
                int countOfCProduct = products.Where(x => x.Id != null && x.Id == "C").Count();
                int countOfDProduct = products.Where(x => x.Id != null && x.Id == "D").Count();
                return GetTotalAProductPrice(countOfAProduct) + GetTotalBProductPrice(countOfBProduct) + GetTotalCDProductPrice(countOfCProduct, countOfDProduct);
            }
            return 0;
        }

        public int GetTotalAProductPrice(int countOfA)
        {
            return (countOfA / 3) * 130 + (countOfA % 3 * Constant.ProductA);
        }

        public int GetTotalBProductPrice(int countOfB)
        {
            return (countOfB / 2) * 45 + (countOfB % 2 * Constant.ProductB);
        }

        public int GetTotalCDProductPrice(int countOfC, int countOfD)
        {
            if (countOfC == countOfD)
                return countOfC * 30;
            else if (countOfC != 0 || countOfD != 0)
                return (countOfC * Constant.ProductC) + (countOfD * Constant.ProductD);
            return 0;
        }
    }
}
