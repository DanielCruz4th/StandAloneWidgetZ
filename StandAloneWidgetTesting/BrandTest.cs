using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;

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
            brand.DateCreated = DateTime.Now;

            //Act
            Brand.Insert(brand);

            //Assert
            Assert.IsNotNull(brand.DateCreated);
        }

        [TestMethod]
        public void BrandFileUdpate()
        {
            //Arrange
            BrandFileCreate();
            var brand = Brand.GetBrands(null, null, null, null).First();
            Guid temp = brand.ID;

            //Act
            brand.LastUdpatedDate = DateTime.Now;
            brand.LastUpdatedBy = "USER2";

            Brand.Update(brand);
            
            //Assert
            var udpateBrand = Brand.GetBrands(temp, null, null, null);
            Assert.IsNotNull(udpateBrand.First().LastUdpatedDate);

        }

        [TestMethod]
        public void BrandFileGetAll()
        {
            BrandFileCreate();

            //Arrange
            var brands = Brand.GetAll();

            //Assert
            Assert.IsTrue(brands.Count > 0);

        }


        [TestMethod]
        public void BrandFileDelete()
        {
            //Arrange
            BrandFileCreate();
            var brandList = Brand.GetBrands(null, null, null, null);
            Guid temp = brandList.First().ID;
                
            //Act
            Brand.Delete(brandList.First());

            //Assert
            Assert.IsTrue(Brand.GetBrands(temp, null, null, null).Count == 0);

        }
    }
}
