using System;
using System.Collections.Generic;
using _03_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgesTests
{
    [TestClass]
    public class BadgeTests
    {
        [TestMethod]
        public void AddBadge_ShouldReturnTrue()
        {
            BadgeRepo repo = new BadgeRepo();
            List<string> doors = new List<string>() { "A5", "B12" };
            Badge badge = new Badge(doors, 1);
            bool addBadge = repo.AddBadge(badge);

            Assert.IsTrue(addBadge);
        }
    }
}
