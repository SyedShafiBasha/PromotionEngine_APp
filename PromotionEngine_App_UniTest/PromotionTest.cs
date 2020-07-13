using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine_App;
using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine_App_UniTest
{
    [TestClass]
    public class PromotionEngineUnitTest
    {
        List<Promotion> listPromotion = null;

        [TestInitialize]
        public void Setup()
        {
            if (listPromotion == null)
            {
                listPromotion = new List<Promotion>();
                listPromotion = Promotion.DefaultProducPromotiont();
            }
            else
            {
                listPromotion = Promotion.DefaultProducPromotiont();
            }

        }


        [TestMethod]
        public void Add_CombinedProduct_GetPromotionTotalPrice()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("B"), new Product("C"), new Product("D") });
            List<int> promoprices = listPromotion.Select(promo => Promotion.GetTotalPrice(order, promo)).ToList();
            int totalPrice = promoprices.Sum();

            Assert.AreEqual(205, totalPrice);
        }

        [TestMethod]
        public void Add_CombinedAndIndividual_GetPromotionTotalPrice()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("A"), new Product("B"), new Product("C"), new Product("A"), new Product("C"), new Product("D") });
            int promoprices = listPromotion.Select(promo => Promotion.GetTotalPrice(order, promo)).ToList().Sum();
            Assert.AreEqual(260, promoprices);
        }

        [TestMethod]
        public void Add_AllProduct_GetTotalPrice()
        {
            Order order = new Order(1, new List<Product>() { new Product("A"), new Product("A"), new Product("B"), new Product("D"), new Product("D"), new Product("D"), new Product("C") });
            int promoprices = listPromotion.Select(promo => Promotion.GetTotalPrice(order, promo)).ToList().Sum();
            Assert.AreEqual(190, promoprices);
        }

    }
}
