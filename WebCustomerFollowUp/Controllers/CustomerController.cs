using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCustomerFollowUp.Models;

namespace WebCustomerFollowUp.Controllers
{ 
    public class CustomerController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Customer/

        public ViewResult Index()
        {
            return View(db.Customer.ToList());
        }

        //
        // GET: /Customer/Details/5

        public ViewResult Details(int id)
        {
            Customer customer = db.Customer.Single(c => c.ID == id);
            return View(customer);
        }

        //
        // GET: /Customer/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Customer/Create

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.AddObject(customer);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(customer);
        }
        
        //
        // GET: /Customer/Edit/5
 
        public ActionResult Edit(int id)
        {
            Customer customer = db.Customer.Single(c => c.ID == id);
            return View(customer);
        }

        //
        // POST: /Customer/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customer.Attach(customer);
                db.ObjectStateManager.ChangeObjectState(customer, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Customer/Delete/5
 
        public ActionResult Delete(int id)
        {
            Customer customer = db.Customer.Single(c => c.ID == id);
            return View(customer);
        }

        //
        // POST: /Customer/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Customer customer = db.Customer.Single(c => c.ID == id);
            db.Customer.DeleteObject(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}