﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SolutionZ.StandAloneWidget
{
    /// <summary>
    /// BrandFile Class
    /// </summary>
    public class Brand
    {

        public Brand()
        {
            this.ID = Guid.NewGuid();
        }
        /// <summary>
        /// BrandFile ID - Guid
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        /// <summary>
        /// Widget Header
        /// </summary>
        public string WidgetHeader { get; set; }

        /// <summary>
        /// Departure Date
        /// </summary>
        public string DepartureDate { get; set; }

        /// <summary>
        /// Length of Stay
        /// </summary>
        public string LenghtOfStaty { get; set; }

        /// <summary>
        /// Address - Default
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// State
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// PostalCode
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Hotel Brand Default
        /// </summary>
        public string HotelBrandDefault { get; set; }

        /// <summary>
        /// Hotel Stars Default
        /// </summary>
        public int HotelStarsRateDefault { get; set; }

        /// <summary>
        /// Date Created - Audit
        /// Must not be null
        /// </summary>
        [Required]
        [HiddenInput(DisplayValue = false)]
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Created By - Audit
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        /// <summary>
        /// Last Updated Date
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public DateTime? LastUdpatedDate { get; set; }

        /// <summary>
        /// Last Updated By
        /// </summary>
        [HiddenInput(DisplayValue = false)]
        public string LastUpdatedBy { get; set; }


        /// <summary>
        /// Creates BrandFile in DB
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static void Insert(Brand brand)
        {
            if (brand == null)
                throw new ArgumentNullException("brand");

            using (var db = new StandAloneWidgetContext())
            {
                db.Brands.Add(brand);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate Brand
        /// </summary>
        /// <param name="brand">Brand instance</param>
        public static void Update(Brand brand)
        {
            if (brand == null)
                throw new ArgumentNullException("brand");

            using (var db = new StandAloneWidgetContext())
            {
                db.Brands.Attach(brand);
                db.Entry(brand).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Brand
        /// </summary>
        /// <param name="brand">Brand instance</param>
        public static void Delete(Brand brand)
        {
            if (brand == null)
                throw new ArgumentNullException("brand");

            using (var db = new StandAloneWidgetContext())
            {
                db.Brands.Attach(brand);
                db.Brands.Remove(brand);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get all Brand Files from DB
        /// </summary>
        /// <returns></returns>
        public static List<Brand> GetBrands(Guid? id, string city, string state, string postalCode)
        {
            List<Brand> list = new List<Brand>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from brand in db.Brands
                            where !id.HasValue || brand.ID == id.Value
                            where string.IsNullOrEmpty(city) || (!string.IsNullOrEmpty(brand.City) && brand.City.Contains(city))
                            where string.IsNullOrEmpty(state) || brand.State == state
                            where string.IsNullOrEmpty(postalCode) || brand.PostalCode == postalCode
                            select brand;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns></returns>
        public static List<Brand> GetAll()
        {
            return Brand.GetBrands( null, null, null, null);
        }


    }
}
