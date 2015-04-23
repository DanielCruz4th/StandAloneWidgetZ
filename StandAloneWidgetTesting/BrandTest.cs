using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Collections.Generic;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class BrandTest
    {
        [TestMethod]
        public void BrandFileCreate()
        {

            //Arrange
            var brand = new Brand();
            brand.ID = Guid.NewGuid();
            brand.WidgetHeader = "Find hotel near 4thsource";
            brand.DepartureDate = "Today + 1";
            brand.LenghtOfStaty = "1 week";
            brand.Address = "1000 Colonial st.";
            brand.City = "Columbia";
            brand.State = "TX";
            brand.PostalCode = "98010-1234";
            brand.HotelBrandDefault = "Westinson";
            brand.HotelStarsRateDefault = 4;
            brand.CreatedBy = "USER";

            //Act
            Brand.Insert(brand);

            //Assert
            Assert.IsNotNull(brand.DateCreated);
        }

        [TestMethod]
        public void BrandFileGetAll()
        {
            BrandFileCreate();

            //Arrange
            var brands = Brand.GetBrands(null, null, null, null);

            //Assert
            Assert.IsTrue(brands.Count > 0);

        }
    }
}
