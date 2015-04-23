using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using SolutionZ.StandAloneWidget.BO;
using SolutionZ.StandAloneWidget.Services;
using System.Collections.Generic;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class BrandFileTst
    {
        [TestMethod]
        public void BrandFile_Create()
        {

            //Arrange
            BrandFile bo = new BrandFile();
            bo.ID = Guid.NewGuid();
            bo.WidgetHeader = "Find hotel near 4thsource";
            bo.DepartureDate = "Today + 1";
            bo.LenghtOfStaty = "1 week";
            bo.Address = "1000 Colonial st.";
            bo.City = "Columbia";
            bo.State = "TX";
            bo.PostalCode = "98010-1234";
            bo.HotelBrandDefault = "Westinson";
            bo.HotelStarsRateDefault = 4;
            bo.CreatedBy = "USER";
            

            //Act
            bo = BrandFileCtrl.Create(bo);

            //Assert
            Assert.IsNotNull(bo.DateCreated);
        }

        [TestMethod]
        public void BrandFile_GetAll()
        {
            //Arrange
            List<BrandFile> brandFiles = new List<BrandFile>();

            //Act
            brandFiles = BrandFileCtrl.GetList();

            //Assert
            Assert.IsTrue(brandFiles.Count > 0);

        }
    }
}
