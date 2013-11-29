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
    public class UrunController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Urun/

        public ViewResult Index()
        {
            return View(db.Urun.ToList());
        }

        //
        // GET: /Urun/Details/5

        public ViewResult Details(int id)
        {
            Urun urun = db.Urun.Single(u => u.id == id);
            return View(urun);
        }

        //
        // GET: /Urun/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Urun/Create

        [HttpPost]
        public ActionResult Create(Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urun.AddObject(urun);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(urun);
        }
        
        //
        // GET: /Urun/Edit/5
 
        public ActionResult Edit(int id)
        {
            Urun urun = db.Urun.Single(u => u.id == id);
            return View(urun);
        }

        //
        // POST: /Urun/Edit/5

        [HttpPost]
        public ActionResult Edit(Urun urun)
        {
            if (ModelState.IsValid)
            {
                db.Urun.Attach(urun);
                db.ObjectStateManager.ChangeObjectState(urun, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urun);
        }

        //
        // GET: /Urun/Delete/5
 
        public ActionResult Delete(int id)
        {
            Urun urun = db.Urun.Single(u => u.id == id);
            return View(urun);
        }

        //
        // POST: /Urun/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Urun urun = db.Urun.Single(u => u.id == id);
            db.Urun.DeleteObject(urun);
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