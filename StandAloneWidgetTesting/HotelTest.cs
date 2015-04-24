using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void HotelCreate()
        {
            //Arrange
            var hotel = new Hotel();
            hotel.ID = Guid.NewGuid();
            hotel.Name = "Ryu Palace";
            hotel.Description = "high style resort";
            hotel.AddressLine1 = "1800 St";
            hotel.AddressLine2 = "Colonia Kukulcan";
            hotel.City = "PlayaCar";
            hotel.State = "QR";
            hotel.Country = "MX";
            hotel.PostalCode = "99999";
            hotel.Latitude = "87.3242342";
            hotel.Longitude = "45.123412";
            hotel.DateCreated = DateTime.Now;
            hotel.CreatedBy = "ADMIN";

            //Act
            Hotel.Insert(hotel);

            //Assert
            Assert.IsNotNull(hotel.DateCreated);


        }

        [TestMethod]
        public void HotelUpdate()
        {
            //Arrange
            HotelCreate();
            var hotel = Hotel.GetHotels(null, null, null, null).First();
            Guid temp = hotel.ID;

            //Act
            hotel.LastUdpatedDate = DateTime.Now;
            hotel.LastUpdatedBy = "UNKNOWN";

            Hotel.Update(hotel);

            //Assert
            var updatedHotel = Hotel.GetHotels(temp, null, null, null);
            Assert.IsNotNull(updatedHotel.First().LastUdpatedDate);


        }

        [TestMethod]
        public void HotelGetAll()
        {
            HotelCreate();

            //Arrange
            var hotels = Hotel.GetHotels(null, null, null, null);

            //Assert
            Assert.IsTrue(hotels.Count > 0);

        }

        [TestMethod]
        public void HotelDelete()
        {
            //Arrange
            HotelCreate();
            var hotelList = Hotel.GetHotels(null, null, null, null);
            Guid temp = hotelList.First().ID;

            //Act
            Hotel.Delete(hotelList.First());

            //Assert
            Assert.IsTrue(Hotel.GetHotels(temp, null, null, null).Count == 0);

        }
    }
}
