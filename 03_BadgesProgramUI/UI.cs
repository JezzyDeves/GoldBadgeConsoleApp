using _03_BadgesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesProgramUI
{
    public class UI
    {
        private readonly BadgeRepo _repo = new BadgeRepo();
        public void Run()
        {
            SeedContent();
            RunMenu();
        }
        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("What would you like to do?\n" +
                    "1) List all badges\n" +
                    "2) Edit a badge\n" +
                    "3) Add new badge\n" +
                    "4) Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //List all badges
                        ListBadges();
                        break;
                    case "2":
                        //Edit a badge
                        break;
                    case "3":
                        //Add new badge
                        AddBadge();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        Console.WriteLine("Press any key to continue.......");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public void ListBadges()
        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            foreach(KeyValuePair<int, List<string>> valuePair in badges)
            {
                String s = String.Format("{0, -5} {1, -10}\n\n", "ID", "Doors");
                string convertID = Convert.ToString(valuePair.Key);
                string doors = string.Join(", ", valuePair.Value);
                s += String.Format("{0, -5} {1, -10}\n", convertID, doors);
                Console.WriteLine($"\n{s}");
            }
            Console.WriteLine("Press any key to continue.......");
            Console.ReadKey();
        }
        public void AddBadge()
        {
            Console.Clear();

            Dictionary<int, List<string>> badges = _repo.GetAllBadges();
            Badge badge = new Badge();
            Console.WriteLine("Enter badge ID number:");
            badge.BadgeID = int.Parse(Console.ReadLine());

            foreach(KeyValuePair<int, List<string>> pair in badges)
            {
                if (badges.ContainsKey(badge.BadgeID))
                {
                    Console.WriteLine("This key already exists please retry");
                    Console.WriteLine("Press any key to continue.......");
                    Console.ReadKey();
                    AddBadge();
                }
            }

            Console.WriteLine("Enter doors for the badge\n" +
                "Seperate each door name with a comma. DO NOT PUT A SPACE AFTER THE COMMA!");
            string doors = Console.ReadLine();
            badge.BadgeDoors = doors.Split(',').ToList();
            _repo.AddBadge(badge);
            Console.WriteLine($"Badge {badge.BadgeID} added");

            Console.WriteLine("Press any key to continue.......");
            Console.ReadKey();
        }
        public void SeedContent()
        {
            BadgeRepo repo = new BadgeRepo();
            List<string> doors = new List<string>() { "A5", "B12" };
            Badge badge = new Badge(1, doors);

            List<string> doors2 = new List<string>() { "A7", "B12", "E3" };
            Badge badge2 = new Badge(2, doors2);
            _repo.AddBadge(badge);
            _repo.AddBadge(badge2);
        }
    }
}
