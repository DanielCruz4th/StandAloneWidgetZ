using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SolutionZ.StandAloneWidget;
using System.Linq;

namespace StandAloneWidgetTesting
{
    [TestClass]
    public class ChainTest
    {
        [TestMethod]
        public void ChainInsert()
        {
            //Arrange
            Chain chain = new Chain() { ID = Guid.NewGuid(), Name = "Caesar Park Hotels", CreatedBy = "ADMIN", DateCreated = DateTime.Now };

            //Act
            Chain.Insert(chain);

            //Assert
            Assert.IsNotNull(chain.DateCreated);

        }

        [TestMethod]
        public void ChainUpdate()
        {
            //Arrange
            ChainInsert();
            var chain = Chain.GetChains(null).First();
            Guid temp = chain.ID;

            //Act
            chain.LastUdpatedDate = DateTime.Now;
            chain.LastUpdatedBy = "UNKNOWN";

            Chain.Update(chain);

            //Assert
            var updatedChain = Chain.GetChains(temp);
            Assert.IsNotNull(updatedChain.First().LastUdpatedDate);


        }

        [TestMethod]
        public void ChainGetAll()
        {
            ChainInsert();

            //Arrange
            var chains = Chain.GetChains(null);

            //Assert
            Assert.IsTrue(chains.Count > 0);

        }

        [TestMethod]
        public void ChainDelete()
        {
            //Arrange
            ChainInsert();
            var chainList = Chain.GetChains(null);
            Guid temp = chainList.First().ID;

            //Act
            Chain.Delete(chainList.First());

            //Assert
            Assert.IsTrue(Chain.GetChains(temp).Count == 0);

        }
    }
}
