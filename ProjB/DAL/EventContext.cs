using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjB.Models;

namespace ProjB.DAL
{
    public class EventContext : DbContext
    {

        public EventContext() : base("EventContext")
        {

            //Database.SetInitializer(new SchoolDBInitializer());
            Database.SetInitializer<EventContext>(new DropCreateDatabaseIfModelChanges<EventContext>());
            //Database.SetInitializer<EventContext>(new CreateDatabaseIfNotExists<EventContext>());
            //Database.SetInitializer<SchoolDBContext>(new SchoolDBInitializer());
        }



        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
    }
}