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
    public class PhonesController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Phones/

        public ViewResult Index()
        {
            var phones = db.Phones.Include("Customer");
            return View(phones.ToList());
        }

        //
        // GET: /Phones/Details/5

        public ViewResult Details(int id)
        {
            Phones phones = db.Phones.Single(p => p.ID == id);
            return View(phones);
        }

        //
        // GET: /Phones/Create

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name");
            return View();
        } 

        //
        // POST: /Phones/Create

        [HttpPost]
        public ActionResult Create(Phones phones)
        {
            if (ModelState.IsValid)
            {
                db.Phones.AddObject(phones);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name", phones.CustomerID);
            return View(phones);
        }
        
        //
        // GET: /Phones/Edit/5
 
        public ActionResult Edit(int id)
        {
            Phones phones = db.Phones.Single(p => p.ID == id);
            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name", phones.CustomerID);
            return View(phones);
        }

        //
        // POST: /Phones/Edit/5

        [HttpPost]
        public ActionResult Edit(Phones phones)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Attach(phones);
                db.ObjectStateManager.ChangeObjectState(phones, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name", phones.CustomerID);
            return View(phones);
        }

        //
        // GET: /Phones/Delete/5
 
        public ActionResult Delete(int id)
        {
            Phones phones = db.Phones.Single(p => p.ID == id);
            return View(phones);
        }

        //
        // POST: /Phones/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Phones phones = db.Phones.Single(p => p.ID == id);
            db.Phones.DeleteObject(phones);
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