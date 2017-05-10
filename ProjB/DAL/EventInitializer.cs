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
                new Event{Name="Hozier",City="Dublin", Venue= "Sin E", Price = 40.00, StartTime="8.45"},
                new Event{ Name = "The Beatles Tribute", City = "Cork", Venue = "Banana Tree", Price = 30.00,StartTime="7.00" },
                new Event{ Name = "The Commitments",City = "Dublin", Venue = "The Olympia", Price = 55.00, StartTime="7.05" },
                new Event{Name="Katie Taylor vs Joanna Jerdiyceck",City="Dublin", Venue= "The Palace", Price = 40.00, StartTime="8.00"},
                new Event{ Name = "Queen ", City = "Cork", Venue = "The Gaiety", Price = 90.00,StartTime="7.45" },
                new Event{Name="The Swiddles",City="Dublin", Venue= "The Globe", Price = 40.00, StartTime="8.45"},
                new Event{ Name = "Party", City = "Cork", Venue = "The Village", Price = 25.00,StartTime="7.00" },
                new Event{ Name = "Micky J",City = "Dublin", Venue = "Sugar Club", Price = 55.00, StartTime="7.05" },
                new Event{Name="Dublin vs Mayo",City="Dublin", Venue= "BallyBoden", Price = 20.00, StartTime="6.00"},
                new Event{ Name = "KnuckleHeads", City = "Cork", Venue = "The Dragon", Price = 45.00,StartTime="7.00" },


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
                new Customer{CustomerID="Lois123@gmail.com",EventID=10},
                new Customer{CustomerID="Sarah4321@gmail.com",EventID=2},
                new Customer{CustomerID="Keara1234@gmail.com",EventID=7},
                new Customer{CustomerID="Elias42@gmail.com",EventID=9},
                new Customer{CustomerID="Steven0987@gmail.com",EventID=8},
                new Customer{CustomerID="Gepp@gmail.com",EventID=8},


                        };

            customer.ForEach(s => context.Customers.Add(s));
            context.SaveChanges();
            base.Seed(context);








        }
    }
}