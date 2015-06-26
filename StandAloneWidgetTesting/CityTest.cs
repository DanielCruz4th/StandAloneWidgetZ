using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class CityTest
    {
        [TestMethod]
        public void CityInsert()
        {
            //Arrange
            City city = new City() { ID = Guid.NewGuid(), Name = "Albuquerque", State = "NM", CreatedBy = "ADMIN", DateCreated = DateTime.Now };

            //Act
            City.Insert(city);

            //Assert
            Assert.IsNotNull(city.DateCreated);

        }

        [TestMethod]
        public void CityUpdate()
        {
            //Arrange
            CityInsert();
            var city = City.GetCities(null, null, null).First();
            Guid temp = city.ID;

            //Act
            city.LastUdpatedDate = DateTime.Now;
            city.LastUpdatedBy = "UNKNOWN";

            City.Update(city);

            //Assert
            var updatedCity = City.GetCities(temp);
            Assert.IsNotNull(updatedCity.First().LastUdpatedDate);


        }

        [TestMethod]
        public void CityGetAll()
        {
            CityInsert();

            //Arrange
            var cities = City.GetCities(null, null, null);

            //Assert
            Assert.IsTrue(cities.Count > 0);

        }

        [TestMethod]
        public void CityDelete()
        {
            //Arrange
            CityInsert();
            var cityList = City.GetCities(null, null, null);
            Guid temp = cityList.First().ID;

            //Act
            City.Delete(cityList.First());

            //Assert
            Assert.IsTrue(City.GetCities(temp).Count == 0);

        }
    }
}
