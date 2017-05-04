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
using PagedList;
using ProjB.ViewModels;

namespace ProjB.Controllers
{
    public class EventsController : Controller
    {
        private EventContext db = new EventContext();

        // GET: Events

        //return View(db.Events.ToList());
        public ActionResult Index(string sortOrder, string searchString, string currentFilter, int? page)
        {

            try
            {
                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                //ViewBag.CitySortParm = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
                ViewBag.PriceSortParm = sortOrder == "Price" ? "price_desc" : "Price";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

                var events = from s in db.Events
                             select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    events = events.Where(s => s.Name.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        events = events.OrderByDescending(s => s.Name);
                        break;
                    //case "City":
                    //    events = events.OrderBy(s => s.City);
                    //    break;
                    //case "city_desc":
                    //    events = events.OrderByDescending(s => s.City);
                    //    break;
                    default:
                        events = events.OrderBy(s => s.Name);
                        break;
                    case "Price":
                        events = events.OrderBy(s => s.Price);
                        break;
                    case "price_desc":
                        events = events.OrderByDescending(s => s.Price);
                        break;
                }

                int pageSize = 6;
                int pageNumber = (page ?? 1);
                return View(events.ToPagedList(pageNumber, pageSize));

            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View();
        }

        public ActionResult About()
        {
            try
            {
                IQueryable<EventTypeGroup> data = from customer in db.Customers
                                                  group customer by customer.EventID into dateGroup
                                                  select new EventTypeGroup()
                                                  {
                                                      EventID = dateGroup.Key,
                                                      
                                                      CustomerCount = dateGroup.Count()
                                                  };


             


                return View(data.ToList());


                
            }
            catch (RetryLimitExceededException  /*dex*/ )
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Index", "Events");
        }




        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventID,Name,City,Venue,Price,StartTime")] Event @event)
        {//For Admin only
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Confirmation/5
        public ActionResult Booking(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Event @event = db.Events.Find(id);
                if (@event == null)
                {
                    return HttpNotFound();
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return RedirectToAction("Create", "Customers"); 
        }
        //---Admin Edit only--//
        // POST: Events/Confirmation/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "EventID,Name,City,Venue,Price,StartTime")] Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@event).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(@event);
        //}


            //--Delete for Admin only--//
        //GET: Events/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = db.Events.Find(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Events/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Event @event = db.Events.Find(id);
        //    db.Events.Remove(@event);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
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
