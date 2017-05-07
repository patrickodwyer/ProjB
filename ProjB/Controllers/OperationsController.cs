using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjB.DAL;
using ProjB.Models;
using System.Data.Entity;

namespace ProjB.Controllers
{
    public class OperationsController : ApiController
    {
        private EventContext db = new EventContext();
        

        

        // GET api/events
        public IHttpActionResult GetAll()
        {
            if (db.Events.Count() == 0)
            {
                return NotFound();
            }

            else
            {
                db.Configuration.ProxyCreationEnabled = false;
                return Ok(db.Events.OrderBy(s => s.Name).ToList());       // 200 OK, listings serialized in response body 
            }
        }
    }
}
