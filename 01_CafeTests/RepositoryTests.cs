using System;
using _02_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void AddMenuItem_ShouldGetTrue()
        {
            string[] burgerIngredients = { "Burger", "Cheese", "Bun" };
            Menu food = new Menu("Cheese Burger", "A tasty cheese burger", 1, burgerIngredients, 2.45);
            MenuRepository repository = new MenuRepository();
            bool addResult = repository.AddMenuItem(food);
            Assert.IsTrue(addResult);
        }
    }
}
