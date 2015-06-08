using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StandAloneWidget.Base;


namespace StandAloneWidgetTesting
{
    [TestClass]
    public class AppSettings
    {
        [TestMethod]
        public void AppSetting_DefaultPageSize()
        {
            //Arrange
            int? test = null;

            //Act
            test = Functions.DefaultPageSize();
            
            //Assert
            Assert.IsNotNull(test);

        }
    }
}
