using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseController : Controller
    {
        Invetory_ManagementEntities db = new Invetory_ManagementEntities();

        // GET: Product
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DispalyPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DispalyPurchase");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Purchase per = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(per);
        }

        [HttpPost]
        public ActionResult Delete(Product prod)
        {
            Purchase per = db.Purchases.Where(x => x.id == prod.id).SingleOrDefault();
            db.Purchases.Remove(per);
            db.SaveChanges();
            return RedirectToAction("DispalyPurchase");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Purchase pur = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(pur);
        }

        [HttpPost]
        public ActionResult Edit(Purchase Pur)
        {
            Purchase pr = db.Purchases.Where(x => x.id == Pur.id).SingleOrDefault();
            db.Purchases.Remove(pr);
            db.Purchases.Add(Pur);
            db.SaveChanges();
            return RedirectToAction("DispalyPurchase");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Purchase Pur = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(Pur);
        }
    }
}