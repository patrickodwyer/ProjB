using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjB.Controllers;
using ProjB.Models;

namespace WebAndLoadTestProject1.ControllerTests
{
    [TestClass]
    public class EventControllerUnitTest
    {
        //[TestMethod]
        //public void IndexTest()
        //{
        //    EventsController controller = new EventsController();
        //    ViewResult result = controller.Index() as ViewResult;
        //    Assert.IsNotNull (result);
        //}

        [TestMethod]
        public void BookingTestRedirect()
        {
            {
                EventsController controller = new EventsController();
              var result =   controller.Booking(1);
                Assert.IsNotNull(result);
            }

        }
        [TestMethod]
        public void CreateTest()
        {
            {
                EventsController controller = new EventsController();
                var result = controller.Create();
                Assert.IsNotNull(result);
            }

        }

    }
}
