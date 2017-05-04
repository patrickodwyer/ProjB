using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjB.DAL;
using ProjB.Models;
using System.Data.Entity.Infrastructure;

namespace ProjB.Controllers
{
    public class CustomersController : Controller
    {
        private EventContext db = new EventContext();

        //Returns to Events List
        public ActionResult Index()
        {
          
           
            return View();
        }

        // GET: Customers/Details/5
        public ActionResult Details()
        {
            
            return RedirectToAction("Index", "Events");
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.EventID = new SelectList(db.Events, "EventID", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,EventID")] Customer customer)
        {
            try
            {
                var uniqueCustomer = db.Customers.FirstOrDefault(s => s.CustomerID == customer.CustomerID);
                if (uniqueCustomer == null)
                {
                    if (ModelState.IsValid)
                    {
                        db.Customers.Add(customer);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    throw new ArgumentException("Customer Email already in use for Valentines Event. To reserve more places, please use alternative email addresses.");
                }
            }
            catch (ArgumentException ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Customers", "Create"));
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.EventID = new SelectList(db.Events, "EventID", "Name", customer.EventID);
            return View(customer);
        }



        // For Admin only--//
        // GET: Customers/Confirmation/5
        

        // POST: Customers/Confirmation/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       

        // GET: Customers/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Customer customer = db.Customers.Find(id);
        //    if (customer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(customer);
        //}

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Customer customer = db.Customers.Find(id);
        //    db.Customers.Remove(customer);
        //    db.SaveChanges();
        //    return RedirectToAction("Create");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
