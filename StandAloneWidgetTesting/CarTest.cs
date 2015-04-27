using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void CarInsert()
        {
            //Arrange
            Car car = new Car() { ID = Guid.NewGuid(), Name = "Caesar Park Hotels", CreatedBy = "ADMIN", DateCreated = DateTime.Now };

            //Act
            Car.Insert(car);

            //Assert
            Assert.IsNotNull(car.DateCreated);

        }

        [TestMethod]
        public void ChainUpdate()
        {
            //Arrange
            CarInsert();
            var car = Car.GetCars(null).First();
            Guid temp = car.ID;

            //Act
            car.LastUdpatedDate = DateTime.Now;
            car.LastUpdatedBy = "UNKNOWN";

            Car.Update(car);

            //Assert
            var updatedChain = Car.GetCars(temp);
            Assert.IsNotNull(updatedChain.First().LastUdpatedDate);


        }

        [TestMethod]
        public void ChainGetAll()
        {
            CarInsert();

            //Arrange
            var chains = Car.GetCars(null);

            //Assert
            Assert.IsTrue(chains.Count > 0);

        }

        [TestMethod]
        public void ChainDelete()
        {
            //Arrange
            CarInsert();
            var chainList = Car.GetCars(null);
            Guid temp = chainList.First().ID;

            //Act
            Car.Delete(chainList.First());

            //Assert
            Assert.IsTrue(Car.GetCars(temp).Count == 0);

        }
    }
}
