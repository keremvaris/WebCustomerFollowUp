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
    public class RenkController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Renk/

        public ViewResult Index()
        {
            return View(db.Renk.ToList());
        }

        //
        // GET: /Renk/Details/5

        public ViewResult Details(int id)
        {
            Renk renk = db.Renk.Single(r => r.id == id);
            return View(renk);
        }

        //
        // GET: /Renk/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Renk/Create

        [HttpPost]
        public ActionResult Create(Renk renk)
        {
            if (ModelState.IsValid)
            {
                db.Renk.AddObject(renk);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(renk);
        }
        
        //
        // GET: /Renk/Edit/5
 
        public ActionResult Edit(int id)
        {
            Renk renk = db.Renk.Single(r => r.id == id);
            return View(renk);
        }

        //
        // POST: /Renk/Edit/5

        [HttpPost]
        public ActionResult Edit(Renk renk)
        {
            if (ModelState.IsValid)
            {
                db.Renk.Attach(renk);
                db.ObjectStateManager.ChangeObjectState(renk, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renk);
        }

        //
        // GET: /Renk/Delete/5
 
        public ActionResult Delete(int id)
        {
            Renk renk = db.Renk.Single(r => r.id == id);
            return View(renk);
        }

        //
        // POST: /Renk/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Renk renk = db.Renk.Single(r => r.id == id);
            db.Renk.DeleteObject(renk);
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