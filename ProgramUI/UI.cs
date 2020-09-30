using _02_Cafe_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeChallenge.UI
{
    public class UI
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
                    "3) Remove a menu item\n" +
                    "4) Exit");
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
                        Console.Clear();
                        Console.Beep();
                        AddItemToMenu();
                        break;
                    case "3":
                        //Remove an item
                        Console.Clear();
                        Console.Beep();
                        RemoveMenuItem();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        public void DisplayAllItems()
        {
            List<Menu> allItems = _repo.GetMenuItems();

            foreach (Menu item in allItems)
            {
                string listOfIngredients = string.Join(", ", item.Ingredients);
                Console.WriteLine($"Name: {item.Name}\n" +
                    $"Description: {item.Description}\n" +
                    $"Meal Number: {item.MealNumber}\n" +
                    $"Ingredients: {listOfIngredients}\n" +
                    $"Price: ${item.Price}\n" +
                    $"-----------------");
            }
        }
        public void AddItemToMenu()
        {
            Menu newMenuItem = new Menu();
            Console.WriteLine("Please enter a name:");
            newMenuItem.Name = Console.ReadLine();
            Console.WriteLine($"Please enter a description for {newMenuItem.Name}:");
            newMenuItem.Description = Console.ReadLine();
            Console.WriteLine($"Enter a menu number for {newMenuItem.Name}:");
            newMenuItem.MealNumber = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Enter an ingredients list for {newMenuItem.Name}\n" +
                $"Each item must be seperated with a comma and the list must not have spaces:");
            string ingredientsList = Console.ReadLine();
            newMenuItem.Ingredients = ingredientsList.Split(',');
            Console.WriteLine($"Please enter a price for {newMenuItem.Name}");
            newMenuItem.Price = Double.Parse(Console.ReadLine());

            Console.Clear();
            _repo.AddMenuItem(newMenuItem);
            Console.WriteLine($"{newMenuItem.Name} was added");
            Console.WriteLine("Press any key to continue........");
            Console.ReadKey();
        }
        public void RemoveMenuItem()
        {
            List<Menu> menuItems = _repo.GetMenuItems();
            if (menuItems.Count == 0)
            {
                Console.WriteLine("There are no items to delete");
                Console.WriteLine("Press any key to continue........");
                Console.ReadKey();
            }
            else
            {
                int count = 0;

                foreach (Menu item in menuItems)
                {
                    count++;
                    Console.WriteLine($"{count}) {item.Name}");
                }
                int targetID = int.Parse(Console.ReadLine());
                int actualID = targetID - 1;

                if (actualID >= 0 && actualID < menuItems.Count)
                {
                    Menu desiredMenuItem = menuItems[actualID];
                    if (_repo.DeleteMenuItem(desiredMenuItem))
                    {
                        Console.WriteLine($"{desiredMenuItem.Name} was successfully removed");
                        Console.WriteLine("Press any key to continue........");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("ERROR");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect ID given");
                    Console.ReadKey();
                }

            }
        }
        public void SeedContent()
        {
            string[] burgerIngredients = { "Burger", "Cheese", "Bun" };
            Menu food1 = new Menu("Cheese Burger", "A tasty cheese burger", 1, burgerIngredients, 2.45);
            string[] chickenSandwich = { "Chicken", "Lettuce", "Bun" };
            Menu food2 = new Menu("Chicken Sandwich", "A tasty chicken sandwich", 2, chickenSandwich, 2.85);
            string[] fries = { "Potato", "Salt" };
            Menu food3 = new Menu("French Fries", "Tasty french fries", 3, fries, 0.99);

            _repo.AddMenuItem(food1);
            _repo.AddMenuItem(food2);
            _repo.AddMenuItem(food3);
        }
    }
}
