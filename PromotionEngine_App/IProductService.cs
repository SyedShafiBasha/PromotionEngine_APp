using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine_App
{
    interface IProductService
    {
        void GetPriceByType(Product product);
        int GetTotalProductPrice(List<Product> products);

        int GetTotalAProductPrice(int countOfA);
        int GetTotalBProductPrice(int countOfB);

        int GetTotalCDProductPrice(int countOfC, int countOfD);
    }
}
