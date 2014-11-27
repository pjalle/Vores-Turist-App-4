using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testturistapp.Model;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace testturistapp.Model.Tests
{
    [TestClass()]
    public class RatingTests
    {
        private Rating _rating;

        [TestInitialize]

        public void beforeTest()
        {
            _rating = new Rating();
        }

        [TestMethod()]
        public void CheckNameTest()
        {
            string testnavn = "";
            for (int i = 0; i < 30; i++)
            {
                testnavn = testnavn + "2";
            }

            string testnavn2 = "";
            for (int i = 0; i < 31; i++)
            {
                testnavn2 = testnavn2 + "a";
            }

            _rating.Name = testnavn;
            Assert.AreEqual(testnavn, _rating.Name);

            try
            {
                _rating.Name = testnavn2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Der skal minimum indtastes 2 cifre, og max 30", ex.Message);
            }
        }

    }
}
