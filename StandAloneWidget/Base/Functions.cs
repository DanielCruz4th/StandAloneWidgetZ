using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace StandAloneWidget.Base
{
    public class Functions
    {
        public static int DefaultPageSize()
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                int val = 0;
                string result = appSettings["DefaultPageSize"] ?? "Not Found";

                if (int.TryParse(result, out val))
                    return val;
                else
                    throw new ConfigurationErrorsException("DefaultPageSize not defined");
            }
            catch(ConfigurationErrorsException)
            {
                throw;
            }
        }

    }
}