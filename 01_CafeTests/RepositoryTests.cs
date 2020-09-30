using System;
using System.Collections.Generic;
using _02_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeTests
{
    [TestClass]
    public class RepositoryTests
    {
        private Menu _item;
        private MenuRepository _repo;
        [TestInitialize]
        public void Arrange()
        {
            string[] burgerIngredients = { "Burger", "Cheese", "Bun" };
            _item = new Menu("Cheese Burger", "A tasty cheese burger", 1, burgerIngredients, 2.45);
            _repo = new MenuRepository();
            _repo.AddMenuItem(_item);
        }
        [TestMethod]
        public void AddMenuItem_ShouldGetTrue()
        {
            string[] burgerIngredients = { "Burger", "Cheese", "Bun" };
            Menu food = new Menu("Cheese Burger", "A tasty cheese burger", 1, burgerIngredients, 2.45);
            MenuRepository repository = new MenuRepository();
            bool addResult = repository.AddMenuItem(food);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void DeleteMenuItem_ShouldGetTrue()
        {
            Menu item = _item;
            bool deleteResult = _repo.DeleteMenuItem(item);

            Assert.IsTrue(deleteResult);
        }
        [TestMethod]
        public void GetMenuItems_ShouldReturnTrue()
        {
            List<Menu> menuItems = _repo.GetMenuItems();
            bool listHasItems = menuItems.Contains(_item);
            Assert.IsTrue(listHasItems);
        }
    }
}
