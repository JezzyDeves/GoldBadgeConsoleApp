using System;
using System.Collections.Generic;
using ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTests
{
    [TestClass]
    public class ClaimsTests
    {
        private Claim _item;
        private ClaimRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            DateTime claimDay = new DateTime(2000, 11, 11);
            DateTime incidentDay = new DateTime(2000, 11, 12);
            _item = new Claim(1, ClaimType.Car, "Car broken", 400, incidentDay, claimDay);
            _repo = new ClaimRepo();
            _repo.AddClaim(_item);
        }

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
        [TestMethod]
        public void GetAllClaims_ShouldReturnTrue()
        {
            List<Claim> claims = _repo.GetAllClaims();
            bool list = claims.Contains(_item);
            Assert.IsTrue(list);
        }
    }
}
