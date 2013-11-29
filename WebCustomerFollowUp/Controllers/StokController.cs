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
    public class StokController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Stok/

        public ViewResult Index()
        {
            var stok = db.stok.Include("Beden").Include("Renk").Include("Urun");
            return View(stok.ToList());
        }

        //
        // GET: /Stok/Details/5

        public ViewResult Details(int id)
        {
            stok stok = db.stok.Single(s => s.id == id);
            return View(stok);
        }

        //
        // GET: /Stok/Create

        public ActionResult Create()
        {
            ViewBag.b_id = new SelectList(db.Beden, "id", "beden1");
            ViewBag.r_id = new SelectList(db.Renk, "id", "renk1");
            ViewBag.u_id = new SelectList(db.Urun, "id", "urun1");
            return View();
        } 

        //
        // POST: /Stok/Create

        [HttpPost]
        public ActionResult Create(stok stok)
        {
            if (ModelState.IsValid)
            {
                db.stok.AddObject(stok);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.b_id = new SelectList(db.Beden, "id", "beden1", stok.b_id);
            ViewBag.r_id = new SelectList(db.Renk, "id", "renk1", stok.r_id);
            ViewBag.u_id = new SelectList(db.Urun, "id", "urun1", stok.u_id);
            return View(stok);
        }
        
        //
        // GET: /Stok/Edit/5
 
        public ActionResult Edit(int id)
        {
            stok stok = db.stok.Single(s => s.id == id);
            ViewBag.b_id = new SelectList(db.Beden, "id", "beden1", stok.b_id);
            ViewBag.r_id = new SelectList(db.Renk, "id", "renk1", stok.r_id);
            ViewBag.u_id = new SelectList(db.Urun, "id", "urun1", stok.u_id);
            return View(stok);
        }

        //
        // POST: /Stok/Edit/5

        [HttpPost]
        public ActionResult Edit(stok stok)
        {
            if (ModelState.IsValid)
            {
                db.stok.Attach(stok);
                db.ObjectStateManager.ChangeObjectState(stok, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.b_id = new SelectList(db.Beden, "id", "beden1", stok.b_id);
            ViewBag.r_id = new SelectList(db.Renk, "id", "renk1", stok.r_id);
            ViewBag.u_id = new SelectList(db.Urun, "id", "urun1", stok.u_id);
            return View(stok);
        }

        //
        // GET: /Stok/Delete/5
 
        public ActionResult Delete(int id)
        {
            stok stok = db.stok.Single(s => s.id == id);
            return View(stok);
        }

        //
        // POST: /Stok/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            stok stok = db.stok.Single(s => s.id == id);
            db.stok.DeleteObject(stok);
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