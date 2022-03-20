using DoDucQuanWADAssignment.Data;
using DoDucQuanWADAssignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;

namespace DoDucQuanWADAssignment.Controllers
{
    public class CartsController : Controller
    {
        private MyDbContext db = new MyDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            Cart cart = Session["cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
            }
            return View("Index", cart.CartItems);
        }

        [HttpGet]
        public ActionResult Add(int productId, int quantity = 1)
        {
            Cart cart = Session["cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
            }
            cart.Add(productId, quantity);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(int productId)
        {
            Cart cart = Session["cart"] as Cart;
            if (cart != null)
            {
                cart.Remove(productId);
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int productId, int quantity)
        {
            Cart cart = Session["cart"] as Cart;
            if (cart != null)
            {
                cart.Update(productId, quantity);
                Session["cart"] = cart;
            }
            return RedirectToAction("Index");
        }
    }
}