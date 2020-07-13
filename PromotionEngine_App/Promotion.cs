using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine_App
{
    public class Promotion
    {
        public int PromotionID { get; set; }
        public Dictionary<string, int> ProductInfo { get; set; }
        public int PromoPrice { get; set; }

        public Promotion(int _promotionID, Dictionary<string, int> _productInfo, int _promoPrice)
        {
            this.PromotionID = _promotionID;
            this.ProductInfo = _productInfo;
            this.PromoPrice = _promoPrice;
        }


        public static List<Promotion> DefaultProducPromotiont()
        {
            Dictionary<String, int> d1 = new Dictionary<String, int>();
            d1.Add("A", 3);
            Dictionary<String, int> d2 = new Dictionary<String, int>();
            d2.Add("B", 2);
            Dictionary<String, int> d3 = new Dictionary<String, int>();
            d3.Add("C", 1);
            d3.Add("D", 1);

            List<Promotion> promotions = new List<Promotion>()
            {
                new Promotion(1, d1, Constant.DiscountPriceOfProductA),
                new Promotion(2, d2, Constant.DiscountPriceOfProductB),
                new Promotion(3, d3, Constant.DiscountPriceOfProductCD)
            };

            return promotions;
        }

        public static List<Promotion> AddNewProductPromotion(List<Promotion> listPromotions)
        {
            var defaultProm = DefaultProducPromotiont();

            foreach (var defaultItem in defaultProm)
            {

                if (!listPromotions.Any(m => m.ProductInfo.Keys.FirstOrDefault().Contains(defaultItem.ProductInfo.Keys.FirstOrDefault())))
                {
                    Dictionary<String, int> d1 = new Dictionary<String, int>();
                    foreach (var item in defaultItem.ProductInfo)
                    {
                        d1.Add(item.Key, item.Value);
                    }

                    Promotion promotion1 = new Promotion(listPromotions.Count() + 1, d1, defaultItem.PromoPrice);
                    listPromotions.Add(promotion1);
                }
            }
            return listPromotions;
        }

        public static int GetTotalPrice(Order ord, Promotion prom)
        {
            int totalForEachItem = 0;
            bool flagItemNotExists = false;
            if (prom.ProductInfo.Count > 1)
            {
                foreach (var item in prom.ProductInfo)
                {
                    var findTotalProductWithSameItem = ord.Products.Where(m => m.Id == item.Key);
                    if (findTotalProductWithSameItem.Count() == 0)
                        flagItemNotExists = true;
                    else if (!flagItemNotExists && findTotalProductWithSameItem.Count() != item.Value)
                        totalForEachItem += (findTotalProductWithSameItem.Count() - item.Value / item.Value) * findTotalProductWithSameItem.Select(m => m.Price).FirstOrDefault();
                    else if (flagItemNotExists)
                        totalForEachItem += (findTotalProductWithSameItem.Count() / item.Value) * findTotalProductWithSameItem.Select(m => m.Price).FirstOrDefault();
                    else
                        totalForEachItem = (findTotalProductWithSameItem.Count() / item.Value) * prom.PromoPrice + (findTotalProductWithSameItem.Count() % item.Value * findTotalProductWithSameItem.Select(m => m.Price).FirstOrDefault());
                }
            }
            else
            {
                foreach (var item in prom.ProductInfo)
                {
                    var findTotalProductWithSameItem = ord.Products.Where(m => m.Id == item.Key);
                    totalForEachItem = (findTotalProductWithSameItem.Count() / item.Value) * prom.PromoPrice + (findTotalProductWithSameItem.Count() % item.Value * findTotalProductWithSameItem.Select(m => m.Price).FirstOrDefault());
                }
            }
            return totalForEachItem;
        }
    }
}
