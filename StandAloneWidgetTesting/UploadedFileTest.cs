using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rainbow.Web.Storage;
using System.IO;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class UploadedFileTest
    {
        [TestMethod]
        public void UploadedFile_Insert()
        {
            //Arrange
            string path = @"c:\Koala.jpg";
            File.Create(path);


            UploadedFile newUploadedFile = new UploadedFile();
            newUploadedFile.InputStream = File.OpenRead(path);
            newUploadedFile.FileName = "koala";

            
            //Act
            newUploadedFile.Save();

        }
    }
}
