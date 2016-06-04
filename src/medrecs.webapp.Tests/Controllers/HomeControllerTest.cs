using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using medrecs.webapp;
using medrecs.webapp.Controllers;

namespace medrecs.webapp.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Team()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Team() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Why()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Why() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
