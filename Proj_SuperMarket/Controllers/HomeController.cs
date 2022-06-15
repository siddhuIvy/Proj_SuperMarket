using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proj_SuperMarket.Models;

namespace Proj_SuperMarket.Controllers
{
    public class HomeController : Controller
    {public ActionResult SalesView()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SalesView(Sales sales)
        {
            return View(db.sales.ToList());
        }
        public ActionResult SalesEdit(int ?id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sales sales = db.sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);

        }
        [HttpPost]
        public ActionResult SalesEdit(Sales sales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("SalesView");
            }
            return View(sales);
        }
        public ActionResult SalesDetail(int id)
        {
            Sales sales = db.sales.Find(id);
            if (sales == null)
            {
                return HttpNotFound();
            }
            return View(sales);

        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Employee objUser)
        {
            using (MarketContext db = new MarketContext())
            {
                var obj = db.Employees.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                if (obj != null)
                {
                    if (obj.Role == "admin")
                    {
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("AdminDashboard");
                    }
                    else
                    {
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("EmpDashboard");
                    }
                }
                else
                {
                    ViewBag.msg = "Enter valid credentials";
                }
            }
            return View();

        }
        public ActionResult AdminDashboard()
        {
            return View();
        }
        public ActionResult EmpDashboard()
        {
            return View();
        }
        public ActionResult ManageEmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ManageEmp(Employee emp)
        {
            using (MarketContext db = new MarketContext())
            {
                db.Employees.Add(emp);
                if (db.SaveChanges() > 0)
                {
                    ViewBag.msg = "Inserted successfully";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "Failed to insert";
                }
            }
            return View();
        }
        private MarketContext db = new MarketContext();

        // GET: Products
        public ActionResult ManageProd()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ProductName,ProductId,ProductPrice,Quantity")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("ManageProd");
            }

            return View(product);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Details(int id)
        {
           
            Product pro = db.Products.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }
        public ActionResult Payment()
        {
            return View();
        }
        public ActionResult ManageSupply()
        {
            return View(db.supplies.ToList());
        }
        public ActionResult Createsup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Createsup([Bind(Include = "id,SupplierName,ProductName")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.supplies.Add(supply);
                db.SaveChanges();
                return RedirectToAction("ManageSupply");
            }

            return View(supply);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,SupplierName,ProductName")] Supply supply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ManageSupply");
            }
            return View(supply);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supply supply = db.supplies.Find(id);
            if (supply == null)
            {
                return HttpNotFound();
            }
            return View(supply);
        }

        // POST: Supplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supply supply = db.supplies.Find(id);
            db.supplies.Remove(supply);
            db.SaveChanges();
            return RedirectToAction("ManageSupply");
        }
    }
}