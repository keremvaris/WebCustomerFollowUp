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
    public class JobController : Controller
    {
        private WebCustomerFollowUpEntities db = new WebCustomerFollowUpEntities();

        //
        // GET: /Job/

        public ViewResult Index()
        {
            var job = db.Job.Include("Customer");
            return View(job.ToList());
        }

        //
        // GET: /Job/Details/5

        public ViewResult Details(int id)
        {
            Job job = db.Job.Single(j => j.ID == id);
            return View(job);
        }

        //
        // GET: /Job/Create

        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name");
            return View();
        } 

        //
        // POST: /Job/Create

        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Job.AddObject(job);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name", job.CustomerID);
            return View(job);
        }
        
        //
        // GET: /Job/Edit/5
 
        public ActionResult Edit(int id)
        {
            Job job = db.Job.Single(j => j.ID == id);
            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name", job.CustomerID);
            return View(job);
        }

        //
        // POST: /Job/Edit/5

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Job.Attach(job);
                db.ObjectStateManager.ChangeObjectState(job, EntityState.Modified);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customer, "ID", "Name", job.CustomerID);
            return View(job);
        }

        //
        // GET: /Job/Delete/5
 
        public ActionResult Delete(int id)
        {
            Job job = db.Job.Single(j => j.ID == id);
            return View(job);
        }

        //
        // POST: /Job/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Job job = db.Job.Single(j => j.ID == id);
            db.Job.DeleteObject(job);
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