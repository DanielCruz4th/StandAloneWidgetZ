using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SolutionZ.StandAloneWidget
{
    public class Chain
    {
        public Chain()
        {
            this.ID = Guid.NewGuid();
        }

        /// <summary>
        /// ID - Guid
        /// </summary>
        [Key]
        public Guid ID { get; set; }

        public int Code { get; set; }

        public string Name { get; set; }

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
        /// Creates Chain in DB
        /// </summary>
        /// <param name="chain"></param>
        /// <returns></returns>
        public static void Insert(Chain chain)
        {
            if (chain == null)
                throw new ArgumentNullException("chain");

            using (var db = new StandAloneWidgetContext())
            {
                db.Chains.Add(chain);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Udpate Chain
        /// </summary>
        /// <param name="chain">Chain instance</param>
        public static void Update(Chain chain)
        {
            if (chain == null)
                throw new ArgumentNullException("chain");

            using (var db = new StandAloneWidgetContext())
            {
                db.Chains.Attach(chain);
                db.Entry(chain).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Delete Chain
        /// </summary>
        /// <param name="chain">Chain instance</param>
        public static void Delete(Chain chain)
        {
            if (chain == null)
                throw new ArgumentNullException("chain");

            using (var db = new StandAloneWidgetContext())
            {
                db.Chains.Attach(chain);
                db.Chains.Remove(chain);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Get Chains from DB
        /// </summary>
        /// <returns></returns>
        public static List<Chain> GetChains(Guid? id)
        {
            List<Chain> list = new List<Chain>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var query = from chain in db.Chains
                            where !id.HasValue || chain.ID == id.Value
                            select chain;

                list.AddRange(query);
            }

            return list;
        }

        /// <summary>
        /// Get ALL chains from DB
        /// </summary>
        /// <returns></returns>
        public static List<Chain> GetAll()
        {
            return GetChains(null);
        }

        public static List<Chain> SearchChains(string query)
        {
            List<Chain> list = new List<Chain>();

            using (var db = new StandAloneWidgetContext())
            {
                //Get from DB
                var results = from chain in db.Chains
                              where (string.IsNullOrEmpty(query)
                                  || (!string.IsNullOrEmpty(chain.Name)
                                  && chain.Name.ToLower().Contains(query.ToLower())))
                              select chain;

                list.AddRange(results);
            }

            return list;
        }




    }
}
