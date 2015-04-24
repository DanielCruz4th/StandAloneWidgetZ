using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;
using System.Text;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class DefaultValueTest
    {
        [TestMethod]
        public void DefaultValueInsert()
        {
            //Arrange 


            var defaultValue = new DefaultValue() {
                DefaultKey = GenerateRandomString(10)
                    , Value = "Hello Moto!" 
                    , DateCreated = DateTime.Now 
                    , CreatedBy = "ANONYMOUS"};

            //Act
            DefaultValue.Insert(defaultValue);

            //Assert
            Assert.IsNotNull(defaultValue.DateCreated);


        }

        [TestMethod]
        public void DefaultValueUdpate()
        {
            //Arrange
            DefaultValueInsert();
            var defaultValue = DefaultValue.GetDefaultValues(null).First();

            //Act
            defaultValue.LastUdpatedDate = DateTime.Now;
            defaultValue.LastUpdatedBy = "USER2";

            DefaultValue.Update(defaultValue);

            //Assert
            var udpatedDefaultValue = DefaultValue.GetDefaultValues(defaultValue.DefaultKey);
            Assert.IsNotNull(udpatedDefaultValue.First().LastUdpatedDate);

        }

        [TestMethod]
        public void DefaultValueAll()
        {
            DefaultValueInsert();

            //Arrange
            var defaultValues = DefaultValue.GetDefaultValues(null);

            //Assert
            Assert.IsTrue(defaultValues.Count > 0);

        }

        [TestMethod]
        public void DefaultValueDelete()
        {
            //Arrange
            DefaultValueInsert();
            var DefaultValueList = DefaultValue.GetDefaultValues(null);
            string key = DefaultValueList.First().DefaultKey;

            //Act
            DefaultValue.Delete(DefaultValueList.First());

            //Assert
            Assert.IsTrue(DefaultValue.GetDefaultValues(key).Count == 0);

        }

        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(characters[random.Next(characters.Length)]);
            }
            return result.ToString();
        }
    }
}
