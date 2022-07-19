using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SaleController : Controller
    {
        Invetory_ManagementEntities db = new Invetory_ManagementEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DispalySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(Sale sal)
        {
            db.Sales.Add(sal);
            db.SaveChanges();
            return RedirectToAction("DispalySale");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.Products.Select(x => x.ProductName).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            Sale s = db.Sales.Where(x => x.id == sale.id).SingleOrDefault();
            db.Sales.Remove(s);
            db.Sales.Add(sale);
            db.SaveChanges();
            return RedirectToAction("DispalySale");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Sale sal = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sal);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Sale Sal = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(Sal);
        }

        [HttpPost]
        public ActionResult Delete(Sale Sal)
        {
            Sale sale = db.Sales.Where(x => x.id == Sal.id).SingleOrDefault();
            db.Sales.Remove(sale);
            db.SaveChanges();
            return RedirectToAction("DispalySale");
        }
    }
}