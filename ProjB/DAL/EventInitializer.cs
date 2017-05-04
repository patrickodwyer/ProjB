using ProjB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ProjB.DAL
{
    public class EventInitializer : DropCreateDatabaseIfModelChanges<EventContext>
    {

        protected override void Seed(EventContext context)
        {
            var @event = new List<Event>
            {
                 new Event{Name="UFC Dublin 210",City="Dublin", Venue= "Aviva Stadium", Price = 40.00, StartTime="7.45"},
                new Event{ Name = "Ireland vs England ", City = "Dublin", Venue = "CrokePArk", Price = 30.00,StartTime="7.45" },
                new Event{ Name = "Garth Brookes", City = "Dublin", Venue = "BroPArk", Price = 50.00, StartTime="7.45" },
                new Event{Name="Speed Dating",City="Cork", Venue= "Hairy Turkey Breast", Price = 25.00, StartTime="7.15"},
                new Event{ Name = "Speed Dating", City = "Galway", Venue = "King's Head", Price = 30.00,StartTime="7.15" },
                new Event{ Name = "Blind Date Night", City = "Athlone", Venue = "Rose's Place", Price = 30.00, StartTime="7.10" },
                new Event{ Name = "an", City = "an", Venue = "an", Price = 30.00, StartTime="7.10" },


                        };

            @event.ForEach(s => context.Events.Add(s));
            context.SaveChanges();
            base.Seed(context);

            var customer = new List<Customer>
            {
                 new Customer{CustomerID="GaryP@gmail.com",EventID=2},
                new Customer{CustomerID="JerryT@gmail.com",EventID=4},
                new Customer{CustomerID="Paul11@gmail.com",EventID=3},
                new Customer{CustomerID="Dave432@gmail.com",EventID=3},
                new Customer{CustomerID="Jason534@gmail.com",EventID=3},
                new Customer{CustomerID="Luke643@gmail.com",EventID=4},
                new Customer{CustomerID="PaddyODW@gmail.com",EventID=5},
                new Customer{CustomerID="GeoP@gmail.com",EventID=4},
                new Customer{CustomerID="TerryP@gmail.com",EventID=1},
                new Customer{CustomerID="KarenN@gmail.com",EventID=4},
                new Customer{CustomerID="Lois123@gmail.com",EventID=1},
                new Customer{CustomerID="Sarah4321@gmail.com",EventID=2},
                new Customer{CustomerID="Keara1234@gmail.com",EventID=3},
                new Customer{CustomerID="Elias42@gmail.com",EventID=4},
                new Customer{CustomerID="Steven0987@gmail.com",EventID=5},
                new Customer{CustomerID="Gepp@gmail.com",EventID=4},


                        };

            customer.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            base.Seed(context);








        }
    }
}