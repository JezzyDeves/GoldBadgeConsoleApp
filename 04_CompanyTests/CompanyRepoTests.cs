using System;
using _04_CompanyRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_CompanyTests
{
    [TestClass]
    public class CompanyRepoTests
    {
        [TestMethod]
        public void AddOuting_ShouldReturnTrue()
        {
            CompanyRepo _repo = new CompanyRepo();
            DateTime dateTime = new DateTime(2000, 12, 12);
            Outing outing = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            bool added = _repo.AddOuting(outing);
            Assert.IsTrue(added);
        }
    }
}
