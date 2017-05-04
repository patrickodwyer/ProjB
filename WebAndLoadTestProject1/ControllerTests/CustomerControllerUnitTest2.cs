using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjB.Controllers;
using System.Web.Mvc;

namespace WebAndLoadTestProject1.ControllerTests
{
    [TestClass]
    public class CustomerControllerUnitTest2
    {

        [TestMethod]
        public void IndexTest()
        {
            CustomersController controller = new CustomersController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void CreateTest()
        {
            
                CustomersController controller = new CustomersController();
                var result = controller.Create();
                Assert.IsNotNull(result);
           
        }
        [TestMethod]
        public void DetailsTestRedirect()
        {
            
            var controller = new CustomersController();
            var result = (RedirectToRouteResult)controller.Details();
            Assert.AreEqual("Index", result.RouteValues["action"]);

        }
      
    

    }
}

    

