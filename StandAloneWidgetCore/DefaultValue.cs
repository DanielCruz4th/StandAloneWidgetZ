using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolutionZ.StandAloneWidget
{
    public class DefaultValue
    {
        [Key]
        public string DefaultKey { get; set; }

        public string Value { get; set; }

        /// <summary>
        /// Date Created - Audit
        /// Must not be null
        /// </summary>
        [Required]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Created By - Audit
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Last Updated Date
        /// </summary>
        public DateTime? LastUdpatedDate { get; set; }

        /// <summary>
        /// Last Updated By
        /// </summary>
        public string LastUpdatedBy { get; set; }


        /// <summary>
        /// Creates Default Value in DB
        /// </summary>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static void Insert(DefaultValue defaultValue)
        {
            if (defaultValue == null)
                throw new ArgumentNullException("defaultValue");

            using (var db = new StandAloneWidgetContext())
            {
                db.DefaultValues.Add(defaultValue);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate Default Value
        /// </summary>
        /// <param name="defaultValue">Default Value instance</param>
        public static void Update(DefaultValue defaultValue)
        {
            if (defaultValue == null)
                throw new ArgumentNullException("defaultValue");

            using (var db = new StandAloneWidgetContext())
            {
                db.DefaultValues.Attach(defaultValue);
                db.Entry(defaultValue).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Default Value
        /// </summary>
        /// <param name="defaultValue">Default Value</param>
        public static void Delete(DefaultValue defaultValue)
        {
            if (defaultValue == null)
                throw new ArgumentNullException("defaultValue");

            using (var db = new StandAloneWidgetContext())
            {
                db.DefaultValues.Attach(defaultValue);
                db.DefaultValues.Remove(defaultValue);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Default Value from DB
        /// </summary>
        /// <returns></returns>
        public static List<DefaultValue> GetDefaultValues(string key)
        {
            List<DefaultValue> list = new List<DefaultValue>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from values in db.DefaultValues
                            where string.IsNullOrEmpty(key) || values.DefaultKey == key
                            select values;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get ALL Default Values from DB
        /// </summary>
        /// <returns></returns>
        public static List<DefaultValue> GetAll()
        {
            return GetDefaultValues(null);
        }

        /// <summary>
        /// Generates Random String Key for Current Instance
        /// </summary>
        /// <param name="length"></param>
        public void GenerateKeyString(int length)
        {
            this.DefaultKey = GenerateRandomString(length);
        }

        /// <summary>
        /// Private Function
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GenerateRandomString(int length)
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
