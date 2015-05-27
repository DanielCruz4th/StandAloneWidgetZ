using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;


namespace SolutionZ.StandAloneWidget
{
    public class Car
    {
        public Car()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// ID - Guid
        /// </summary>
        [Key]
        [HiddenInput(DisplayValue = false)]
        public Guid ID { get; set; }

        public string Name { get; set; }

        [MaxLength(2)]
        public string Code { get; set; }

        [Display(Name="Company text")]
        public string CompanyText { get; set;}

        [Display(Name = "Title tag")]
        public string TitleTag { get; set; }

        [Display(Name = "Phone number")]
        public string PrimaryPhoneNumber { get; set; }

        [Display(Name = "Alternate phone number")]
        public string SecondaryPhoneNumber { get; set; }

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
        /// Creates Car in DB
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        public static void Insert(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("car");

            using (var db = new StandAloneWidgetContext())
            {
                db.Cars.Add(car);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate Car
        /// </summary>
        /// <param name="chain">Car instance</param>
        public static void Update(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("car");

            using (var db = new StandAloneWidgetContext())
            {
                db.Cars.Attach(car);
                db.Entry(car).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Car
        /// </summary>
        /// <param name="car">Car instance</param>
        public static void Delete(Car car)
        {
            if (car == null)
                throw new ArgumentNullException("car");

            using (var db = new StandAloneWidgetContext())
            {
                db.Cars.Attach(car);
                db.Cars.Remove(car);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Cars from DB
        /// </summary>
        /// <returns></returns>
        public static List<Car> GetCars(Guid? id)
        {
            List<Car> list = new List<Car>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from car in db.Cars
                            where !id.HasValue || car.ID == id.Value
                            select car;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get ALL Cars from DB
        /// </summary>
        /// <returns></returns>
        public static List<Car> GetAll()
        {
            return GetCars(null);
        }
    }
}
