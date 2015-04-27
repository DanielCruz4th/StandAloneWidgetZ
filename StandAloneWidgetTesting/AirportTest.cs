using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class AirportTest
    {
        [TestMethod]
        public void AirportInsert()
        {
            //Arrange
            Airport airport = new Airport();
            airport.ID = Guid.NewGuid();
            airport.Name = "Ushuaia, Tierra Del Fuego, Argentina";
            airport.Code = "USH";
            airport.Latitude = "-54.8106";
            airport.Longitude = "-68.3278";
            airport.CreatedBy = "ADMIN";
            airport.DateCreated = DateTime.Now ;

            //Act
            Airport.Insert(airport);

            //Assert
            Assert.IsNotNull(airport.DateCreated);

        }

        [TestMethod]
        public void AirportUpdate()
        {
            //Arrange
            AirportInsert();
            var airport = Airport.GetAirports(null).First();
            Guid temp = airport.ID;

            //Act
            airport.LastUdpatedDate = DateTime.Now;
            airport.LastUpdatedBy = "UNKNOWN";

            Airport.Update(airport);

            //Assert
            var updatedChain = Airport.GetAirports(temp);
            Assert.IsNotNull(updatedChain.First().LastUdpatedDate);


        }

        [TestMethod]
        public void AirportGetAll()
        {
            AirportInsert();

            //Arrange
            var chains = Airport.GetAirports(null);

            //Assert
            Assert.IsTrue(chains.Count > 0);

        }

        [TestMethod]
        public void AirportDelete()
        {
            //Arrange
            AirportInsert();
            var airportList = Airport.GetAirports(null);
            Guid temp = airportList.First().ID;

            //Act
            Airport.Delete(airportList.First());

            //Assert
            Assert.IsTrue(Airport.GetAirports(temp).Count == 0);

        }
    }
}
