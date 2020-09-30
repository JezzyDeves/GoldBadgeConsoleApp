using _02_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeChallenge.UI
{
    public class ProgramUI
    {
        private readonly MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            Console.Title = "Cafe Menu";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;

            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("What do you want to do?\n" +
                    "1) Show all menu items\n" +
                    "2) Add a menu item\n" +
                    "3) Remove a menu item");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //Show all items
                        Console.Clear();
                        Console.Beep();
                        DisplayAllItems();
                        Console.WriteLine("Press any key to continue.......");
                        Console.ReadKey();
                        break;
                    case "2":
                        //Add an item
                        Console.Beep();
                        break;
                    case "3":
                        //Remove an item
                        Console.Beep();
                        break;
                }
            }
        }
        public void DisplayAllItems()
        {
            List<Menu> allItems = _repo.GetMenuItems();

            foreach(Menu item in allItems)
            {
                Console.WriteLine($"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Meal Number: {item.MealNumber}\n" +
                    $"Ingredients: {item.Ingredients}\n" +
                    $"Price: ${item.Price}\n" +
                    $"-----------------");
            }
        }
        public void SeedContent()
        {
            string[] burgerIngredients = { "Burger", "Cheese", "Bun" };
            Menu food1 = new Menu("Cheese Burger", "A tasty cheese burger", 1, burgerIngredients, 2.45);
            _repo.AddMenuItem(food1);
        }
    }
}
