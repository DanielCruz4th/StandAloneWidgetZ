using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;
using SolutionZ.StandAloneWidget;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class JsonLoaderTest
    {
        [TestMethod]
        public void JsonLoaderAirVendorTest()
        {
            //Load file
            var json = System.IO.File.ReadAllText(@"c:\jsonfiles\airVendors.json");
            var objects = JArray.Parse(json);

            foreach(var item in objects.Children())
            {
                var itemProperties = item.Children<JProperty>();
                
                var myElementKey = itemProperties.FirstOrDefault(x => x.Name == "key");
                var myElementKeyValue = myElementKey.Value;

                var myElementValue = itemProperties.FirstOrDefault(x => x.Name == "value");
                var myElementValueVal = myElementValue.Value;


                AirVendor newAirVendor = new AirVendor() { Name = myElementValueVal.ToString(), Code = myElementKeyValue.ToString() };

                AirVendor.Insert(newAirVendor);
                
            }
        }

        [TestMethod]
        public void JsonLoaderCabinClassTest()
        {
            //Load file
            var json = System.IO.File.ReadAllText(@"c:\jsonfiles\cabinClasses.json");
            var objects = JArray.Parse(json);

            foreach (var item in objects.Children())
            {
                var itemProperties = item.Children<JProperty>();

                var myElementKey = itemProperties.FirstOrDefault(x => x.Name == "key");
                var myElementKeyValue = myElementKey.Value;

                var myElementValue = itemProperties.FirstOrDefault(x => x.Name == "value");
                var myElementValueVal = myElementValue.Value;


                CabinClass newCabinClass = new CabinClass() { Name = myElementValueVal.ToString(), Code = myElementKeyValue.ToString() };

                CabinClass.Insert(newCabinClass);

            }
        }

        [TestMethod]
        public void JsonLoaderCarCompanies()
        {
            //Load file
            var json = System.IO.File.ReadAllText(@"c:\jsonfiles\carCompanies.json");
            var objects = JArray.Parse(json);

            foreach (var item in objects.Children())
            {
                var itemProperties = item.Children<JProperty>();

                var myElementName = itemProperties.FirstOrDefault(x => x.Name == "name");
                var myElementNameValue = myElementName.Value;

                var myElementCode = itemProperties.FirstOrDefault(x => x.Name == "code");
                var myElementCodeValue = myElementCode.Value;

                var myElementTitle = itemProperties.FirstOrDefault(x => x.Name == "title");
                var myElementTitleValue = myElementTitle.Value;

                var myElementPhone = itemProperties.FirstOrDefault(x => x.Name == "phone");
                var myElementPhoneValue = myElementPhone.Value;

                var myElementAlternate = itemProperties.FirstOrDefault(x => x.Name == "alternate");
                var myElementAlternateValue = myElementAlternate.Value;

                Car newCar = new Car();
                newCar.Name = myElementNameValue.ToString();
                newCar.Code = myElementCodeValue.ToString();
                newCar.TitleTag = myElementTitleValue.ToString();
                newCar.PrimaryPhoneNumber = myElementPhoneValue.ToString();
                newCar.SecondaryPhoneNumber = myElementAlternateValue.ToString();
                newCar.CreatedBy = "ADMIN";
                newCar.DateCreated = DateTime.Now;

                Car.Insert(newCar);

            }
        }


    }
}
