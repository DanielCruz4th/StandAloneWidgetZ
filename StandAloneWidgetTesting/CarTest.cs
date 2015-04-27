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
        public void CarUpdate()
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
            var updatedCar = Car.GetCars(temp);
            Assert.IsNotNull(updatedCar.First().LastUdpatedDate);


        }

        [TestMethod]
        public void CarGetAll()
        {
            CarInsert();

            //Arrange
            var cars = Car.GetCars(null);

            //Assert
            Assert.IsTrue(cars.Count > 0);

        }

        [TestMethod]
        public void CarDelete()
        {
            //Arrange
            CarInsert();
            var carList = Car.GetCars(null);
            Guid temp = carList.First().ID;

            //Act
            Car.Delete(carList.First());

            //Assert
            Assert.IsTrue(Car.GetCars(temp).Count == 0);

        }
    }
}
