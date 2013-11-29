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
    public class SatisController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Satis/

        public ViewResult Index()
        {
            var satis = db.Satis.Include("Customer").Include("stok");
            return View(satis.ToList());
        }

        //
        // GET: /Satis/Details/5

        public ViewResult Details(int id)
        {
            Satis satis = db.Satis.Single(s => s.id == id);
            return View(satis);
        }

        //
        // GET: /Satis/Create

        public ActionResult Create()
        {
            ViewBag.musid = new SelectList(db.Customer, "ID", "Name");
            ViewBag.stokid = new SelectList(db.stok, "id", "StokAdi");
            return View();
        } 

        //
        // POST: /Satis/Create

        [HttpPost]
        public ActionResult Create(Satis satis)
        {
            if (ModelState.IsValid)
            {
                db.Satis.AddObject(satis);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.musid = new SelectList(db.Customer, "ID", "Name", satis.musid);
            ViewBag.stokid = new SelectList(db.stok, "id", "StokAdi", satis.stokid);
            return View(satis);
        }
        
        //
        // GET: /Satis/Edit/5
 
        public ActionResult Edit(int id)
        {
            Satis satis = db.Satis.Single(s => s.id == id);
            ViewBag.musid = new SelectList(db.Customer, "ID", "Name", satis.musid);
            ViewBag.stokid = new SelectList(db.stok, "id", "StokAdi", satis.stokid);
            return View(satis);
        }

        //
        // POST: /Satis/Edit/5

        [HttpPost]
        public ActionResult Edit(Satis satis)
        {
            if (ModelState.IsValid)
            {
                db.Satis.Attach(satis);
                db.ObjectStateManager.ChangeObjectState(satis, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.musid = new SelectList(db.Customer, "ID", "Name", satis.musid);
            ViewBag.stokid = new SelectList(db.stok, "id", "StokAdi", satis.stokid);
            return View(satis);
        }

        //
        // GET: /Satis/Delete/5
 
        public ActionResult Delete(int id)
        {
            Satis satis = db.Satis.Single(s => s.id == id);
            return View(satis);
        }

        //
        // POST: /Satis/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Satis satis = db.Satis.Single(s => s.id == id);
            db.Satis.DeleteObject(satis);
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