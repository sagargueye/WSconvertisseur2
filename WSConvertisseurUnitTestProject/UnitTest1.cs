using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSconvertisseur2.Controllers;
using WSconvertisseur2.Models;

namespace WSConvertisseurUnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsOkObjectResult()
        {
            // Arrange
            var controller = new DeviseController();
            // Act
            var result = controller.GetById(1);
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult), "Pas un OkObjectResult");
        }
        [TestMethod]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            var _controller = new DeviseController();
            // Act
            var result = _controller.GetById(1) as OkObjectResult;
            // Assert
            Assert.IsInstanceOfType(result.Value, typeof(Devise), "Pas une Devise");
            Assert.AreEqual(new Devise(1, "dollars", 1.08), (Devise)result.Value, "Devises pas identiques");
}
        [TestMethod]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Arrange
            var _controller = new DeviseController();
            // Act
            var result = _controller.GetById(20);
            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult), "Pas un NotFoundResult");
        }
    }
}
