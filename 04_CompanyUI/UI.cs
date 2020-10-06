using _04_CompanyRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyUI
{
    public class UI
    {
        private readonly CompanyRepo _repo = new CompanyRepo();
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

                Console.WriteLine("What do you want to do?\n" +
                    "1) Show all outings\n" +
                    "2) Add outing\n" +
                    "3) Display outings based on type\n" +
                    "4) Exit");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        //Show all
                        ListOutings();
                        break;
                    case "2":
                        //Add
                        AddOuting();
                        break;
                    case "3":
                        //Show cost by type
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                }
            }
        }
        public void ListOutings()
        {
            Console.Clear();

            List<Outing> outings = _repo.GetOutings();
            foreach (Outing outing in outings)
            {
                Console.WriteLine($"Type: {outing.TypeOfEvent}\n" +
                    $"People: {outing.People}\n" +
                    $"Date: {outing.Date}\n" +
                    $"Cost per person: {outing.CostPerson}\n" +
                    $"Total cost: {outing.CostTotal}\n\n");
            }
            Console.WriteLine("Press any key to continue.......");
            Console.ReadKey();
        }
        public void AddOuting()
        {
            Console.Clear();

            Outing outing = new Outing();
            Console.WriteLine("What type of event do you want to add?\n" +
                "1) Golf\n" +
                "2) Bowling\n" +
                "3) Amusement Park\n" +
                "4) Concert");
            switch (Console.ReadLine())
            {
                case "1":
                    outing.TypeOfEvent = EventType.Golf;
                    break;
                case "2":
                    outing.TypeOfEvent = EventType.Bowling;
                    break;
                case "3":
                    outing.TypeOfEvent = EventType.AmusementPark;
                    break;
                case "4":
                    outing.TypeOfEvent = EventType.Concert;
                    break;
                default:
                    Console.WriteLine("ERROR invalid type");
                    Console.WriteLine("Press any key to continue.......");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("How many people attended?");
            outing.People = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date (yyyy/mm/dd):");
            outing.Date = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", null);
            Console.WriteLine("Enter cost per person:");
            outing.CostPerson = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the total cost:");
            outing.CostTotal = Convert.ToDouble(Console.ReadLine());
            _repo.AddOuting(outing);
        }
        public void SeedContent()
        {
            DateTime dateTime = new DateTime(2000, 12, 12);
            Outing outing = new Outing(EventType.Golf, 100, dateTime, 15.45, 2000);
            _repo.AddOuting(outing);
            DateTime dateTime2 = new DateTime(2004, 09, 18);
            Outing outing2 = new Outing(EventType.Bowling, 157, dateTime2, 15.45, 1500);
            _repo.AddOuting(outing2);
        }
    }
}
