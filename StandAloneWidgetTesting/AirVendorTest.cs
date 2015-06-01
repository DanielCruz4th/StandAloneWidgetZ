using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class AirVendorTest
    {
        [TestMethod]
        public void AirVendorInsert()
        {
            //Arrange
            AirVendor airVendor = new AirVendor();
            airVendor.Code = "A3";
            airVendor.Name = "Aegean";

            //Act
            AirVendor.Insert(airVendor);

            //Assert
            Assert.IsTrue(true);

        }
    }
}
