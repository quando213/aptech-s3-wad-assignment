using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoDucQuanWADAssignment.Data;
using DoDucQuanWADAssignment.Models;

namespace DoDucQuanWADAssignment.Controllers
{
    public class HomeController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: Products
        public ActionResult Index()
        {
            var product = db.Product.Include(p => p.Category);
            ViewBag.Categories = db.Category.ToList();
            return View(product.ToList());
        }

        public ActionResult GetProducts()
        {
            var product = db.Product.AsQueryable();

            if (Request.QueryString["categoryId"] != null)
            {
                int categoryId = int.Parse(this.Request.QueryString["categoryId"]);
                if (categoryId != -1)
                {
                    product = product.Where(s => s.CategoryId == categoryId);
                }
            }
            if (Request.QueryString["searchString"] != null)
            {
                string searchString = this.Request.QueryString["searchString"];
                if (!String.IsNullOrWhiteSpace(searchString))
                {
                    product = product.Where(s => s.Name.Contains(searchString.Trim()));
                }
            }
            return PartialView("ProductCard", product.ToList());
        }
    }
}