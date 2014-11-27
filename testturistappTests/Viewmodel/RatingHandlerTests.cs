using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testturistapp.Viewmodel;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
namespace testturistapp.Viewmodel.Tests
{
    [TestClass()]
    public class RatingHandlerTests
    {
        private RatingHandler _ratingHandler;

        [TestInitialize]
        public void Beforetest()
        {
            _ratingHandler = new RatingHandler();
        }
        
        [TestMethod()]
        public void CheckNameTest()
        {
            string navn = "";
            for (int i = 0; i < 16; i++)
            {
                navn = navn + "J";
            }

            string navn2 = "";
            for (int i = 0; i < 50; i++)
            {
                navn2 = navn2 + "a";
            }
            _ratingHandler.Name = navn;
            Assert.AreEqual(navn, _ratingHandler.Name);

            try
            {
                _ratingHandler.Name = navn2;
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("N", ex.Message);
            }
        }

        [TestMethod()]
        public void RatingHandlerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void opretRatingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void sletRatingTest()
        {
            Assert.Fail();
        }
    }
}
