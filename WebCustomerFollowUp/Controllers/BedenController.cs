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
    public class BedenController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Beden/

        public ViewResult Index()
        {
            return View(db.Beden.ToList());
        }

        //
        // GET: /Beden/Details/5

        public ViewResult Details(int id)
        {
            Beden beden = db.Beden.Single(b => b.id == id);
            return View(beden);
        }

        //
        // GET: /Beden/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Beden/Create

        [HttpPost]
        public ActionResult Create(Beden beden)
        {
            if (ModelState.IsValid)
            {
                db.Beden.AddObject(beden);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(beden);
        }
        
        //
        // GET: /Beden/Edit/5
 
        public ActionResult Edit(int id)
        {
            Beden beden = db.Beden.Single(b => b.id == id);
            return View(beden);
        }

        //
        // POST: /Beden/Edit/5

        [HttpPost]
        public ActionResult Edit(Beden beden)
        {
            if (ModelState.IsValid)
            {
                db.Beden.Attach(beden);
                db.ObjectStateManager.ChangeObjectState(beden, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beden);
        }

        //
        // GET: /Beden/Delete/5
 
        public ActionResult Delete(int id)
        {
            Beden beden = db.Beden.Single(b => b.id == id);
            return View(beden);
        }

        //
        // POST: /Beden/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Beden beden = db.Beden.Single(b => b.id == id);
            db.Beden.DeleteObject(beden);
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