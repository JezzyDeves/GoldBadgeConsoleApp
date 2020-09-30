using System;
using ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        [TestMethod]
        public void AddClaim_ShouldReturnTrue()
        {
            DateTime claimDay = new DateTime(2000, 11, 11);
            DateTime incidentDay = new DateTime(2000, 11, 12);
            Claim claim = new Claim(1, ClaimType.Car, "Car broken", 400, incidentDay, claimDay);
            ClaimRepo repo = new ClaimRepo();
            bool addClaim = repo.AddClaim(claim);
            Assert.IsTrue(addClaim);
        }
    }
}
