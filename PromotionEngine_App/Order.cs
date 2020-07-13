using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine_App
{
    public class Order
    {
        public int OrderID { get; set; }
        public List<Product> Products { get; set; }

        public Order(int _orderId, List<Product> _products)
        {
            this.OrderID = _orderId;
            this.Products = _products;
        }
    }
}
