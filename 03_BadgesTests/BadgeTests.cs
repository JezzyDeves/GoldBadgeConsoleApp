using System;
using System.Collections.Generic;
using _03_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgesTests
{
    [TestClass]
    public class BadgeTests
    {
        private Badge _item;
        private BadgeRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgeRepo();
            List<string> doors = new List<string>() { "A5", "B12" };
            _item = new Badge(1, doors);
            _repo.AddBadge(_item);
        }
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            BadgeRepo repo = new BadgeRepo();
            List<string> doors = new List<string>() { "A5", "B12" };
            Badge badge = new Badge(1, doors);
            bool addBadge = repo.AddBadge(badge);

            Assert.IsTrue(addBadge);
        }
        [TestMethod]
        public void UpdateBadge()
        {
            bool update = _repo.AddBadgeDoors(1, "B2");
            Assert.IsTrue(update);
        }
    }
}
