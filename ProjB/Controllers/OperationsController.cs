using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjB.DAL;
using ProjB.Models;


namespace ProjB.Controllers
{
    public class OperationsController : ApiController
    {
        private EventContext db = new EventContext();

        // must have default constructor
        // todo: use dependency injection and repository pattern

        // GET api/events
        public IHttpActionResult GetAll()
        {
            if (db.Events.Count() == 0)
            {
                return NotFound();
            }

            else
            {
                return Ok(db.Events.OrderByDescending(w => w.Name).ToList());       // 200 OK, listings serialized in response body 
            }
        }
    }
}
