using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class CabinClassTest
    {
        [TestMethod]
        public void CabinClassInsert()
        {
            //Arrange
            CabinClass cabin = new CabinClass();
            cabin.Code = "first";
            cabin.Name = "First Class";

            //Act
            CabinClass.Insert(cabin);

            //Assert
            Assert.IsTrue(true);
        }
    }
}
