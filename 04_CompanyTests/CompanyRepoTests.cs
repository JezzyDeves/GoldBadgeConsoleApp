using System;
using System.Collections.Generic;
using _04_CompanyRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_CompanyTests
{
    [TestClass]
    public class CompanyRepoTests
    {
        private CompanyRepo _repo;
        private Outing _outing;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CompanyRepo();
            DateTime dateTime = new DateTime(2000, 12, 12);
            _outing = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            _repo.AddOuting(_outing);
        }
        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            CompanyRepo _repo = new CompanyRepo();
            DateTime dateTime = new DateTime(2000, 12, 12);
            Outing outing = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            bool added = _repo.AddOuting(outing);
            Assert.IsTrue(added);
        }
        [TestMethod]
        public void GetOutings_ShouldReturnCorrectValue()
        {
            List<Outing> outings = _repo.GetOutings();
            bool containsItem = outings.Contains(_outing);
            Assert.IsTrue(containsItem);
        }
        [TestMethod]
        public void GetTotal_ShouldReturnCorrectValue()
        {
            DateTime dateTime = new DateTime(2000, 12, 12);
            Outing outing = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            DateTime dateTime1 = new DateTime(2000, 12, 12);
            Outing outing1 = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            _repo.AddOuting(outing);
            _repo.AddOuting(outing1);
            double total = _repo.TotalCost();
            Assert.AreEqual(total, 6000);
            Console.WriteLine(total);
        }
        [TestMethod]
        public void GetCostByType_ShouldReturnCorrectValue()
        {
            DateTime dateTime = new DateTime(2000, 12, 12);
            Outing outing = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            _repo.AddOuting(outing);
            double getCost = _repo.GetCostByType(EventType.Golf);
            Assert.AreEqual(getCost, 4000);
            Console.WriteLine(getCost);
        }
    }
}
