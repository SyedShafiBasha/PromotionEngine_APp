using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine_App;
using System.Collections.Generic;

namespace PromotionEngine_App_UniTest
{
    [TestClass]
    public class PromotionEngineUnitTest
    {
        ProductService productService = new ProductService();
        List<Product> listProduct = null;

        [TestInitialize]
        public void Setup()
        {
            listProduct = new List<Product>();
            for (int i = 0; i < 3; i++)
            {
                Product product = new Product();
                product.Id = "A";
                productService.GetPriceByType(product);
                listProduct.Add(product);
            }
            for (int i = 0; i < 2; i++)
            {
                Product product = new Product();
                product.Id = "B";
                productService.GetPriceByType(product);
                listProduct.Add(product);
            }
        }


        [TestMethod]
        public void Add_ThreeAProduct_GetDiscountPrice()
        {
            var getPriceOfA = productService.GetTotalAProductPrice(3);
            Assert.AreEqual(130, getPriceOfA);
        }

        [TestMethod]
        public void Add_TwoBProduct_GetDiscountPrice()
        {
            var getPriceOfA = productService.GetTotalBProductPrice(2);
            Assert.AreEqual(45, getPriceOfA);
        }

        [TestMethod]
        public void Add_AllProduct_GetTotalPrice()
        {
            var getTotalPrice = productService.GetTotalProductPrice(listProduct);
            Assert.AreEqual(175, getTotalPrice);
        }

    }
}
