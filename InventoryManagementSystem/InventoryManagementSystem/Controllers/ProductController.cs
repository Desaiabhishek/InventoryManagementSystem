using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        Invetory_ManagementEntities db = new Invetory_ManagementEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DispalyProduct()
        {
            List<Product> list = db.Products.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(Product prod)
        {
            db.Products.Add(prod);
            db.SaveChanges();
            return RedirectToAction("DispalyProduct");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            Product pr = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(pr);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product prod)
        {
            Product pr = db.Products.Where(x => x.id == prod.id).SingleOrDefault();
            db.Products.Remove(pr);
            db.Products.Add(prod);
            db.SaveChanges();
            return RedirectToAction("DispalyProduct");
        }

        [HttpGet]
        public ActionResult ProductDetails(int id)
        {
            Product prod = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(prod);
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            Product prod = db.Products.Where(x => x.id == id).SingleOrDefault();
            return View(prod);
        }

        [HttpPost]
        public ActionResult DeleteProduct(Product prod)
        {
            Product pr = db.Products.Where(x => x.id == prod.id).SingleOrDefault();
            db.Products.Remove(pr);
            db.SaveChanges();
            return RedirectToAction("DispalyProduct");
        }
    }
}