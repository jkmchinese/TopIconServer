using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopIconServer;
using TopIconServer.Controllers;
using TopIconServer.Models;

namespace TopIconServer.Tests.Controllers
{
    [TestClass]
    public class IconsetsControllerTest
    {
        [TestMethod]
        public void Get()
        {
            IconsetsController controller = new IconsetsController();

            // Act
            // IEnumerable<string> result = controller.Get();

            // Assert
            //Assert.IsNotNull(result);
            //Assert.AreEqual(2, result.Count());
            //Assert.AreEqual("value1", result.ElementAt(0));
            //Assert.AreEqual("value2", result.ElementAt(1));
        }

        [TestMethod]
        public void GetById()
        {
            //// Arrange
            //IconsetController controller = new IconsetController();

            //// Act
            //string result = controller.Get(5);

            //// Assert
            //Assert.AreEqual("value", result);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            IconsetsController controller = new IconsetsController();

            // Act
            //controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            //IconSetController controller = new IconSetController();

            // Act
            //controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            //IconSetController controller = new IconSetController();

            // Act
            //controller.Delete(5);

            // Assert
        }
    }
}
