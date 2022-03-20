using DoDucQuanWADAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoDucQuanWADAssignment.Models
{
    public class Cart
    {
        private MyDbContext db = new MyDbContext();
        public string ShippingName { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingPhone { get; set; }
        public Dictionary<int, CartItem> CartItems { get; set; }
        public Cart()
        {
            CartItems = new Dictionary<int, CartItem>();
        }

        public void Add(int productId, int quantity = 1)
        {
            if (!CartItems.ContainsKey(productId))
            {
                Product product = db.Product.Find(productId);
                CartItems.Add(
                    productId,
                    new CartItem()
                    {
                        ProductId = productId,
                        ProductName = product.Name,
                        Quantity = quantity,
                        UnitPrice = product.Price,
                    }
                    );
            }
            else
            {
                CartItems[productId].Quantity += quantity;
            }
        }

        public void Remove(int productId)
        {
            if (CartItems.ContainsKey(productId))
            {
                CartItems.Remove(productId);
            }
        }

        public void Clear()
        {
            CartItems.Clear();
        }

        public void Update(int productId, int quantity)
        {
            CartItems[productId].Quantity = quantity;
        }
    }
}