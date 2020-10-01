using ClaimsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claims_ProgramUI
{
    public class UI
    {
        private readonly ClaimRepo _repo = new ClaimRepo();
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
                    "1) View claims\n" +
                    "2) Enter new claim\n" +
                    "3) Take care of claim\n" +
                    "4) Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        //View claims
                        ShowAllClaims();
                        break;
                    case "2":
                        //Enter new claim
                        break;
                    case "3":
                        //Take care of claim
                        break;
                    case "4":
                        //Exit
                        continueToRun = false;
                        break;
                }
            }
        }
        public void ShowAllClaims()
        {
            Console.Clear();
            List<Claim> claims = _repo.GetAllClaims();

            //Console.WriteLine("Claim ID\t" +
            //    "Claim Type\t" +
            //    "Description\t" +
            //    "Ammount\t" +
            //    "Incident Date\t" +
            //    "Claim Date\t" +
            //    "Valid");

            foreach(Claim claim in claims)
            {
                //Console.WriteLine(string.Format($"{claim.ClaimID}\t" +
                //    $"{claim.TypeOfClaim}\t" +
                //    $"{claim.Description}\t" +
                //    $"{claim.ClaimAmmount}\t" +
                //    $"{claim.DateOfIncident}\t" +
                //    $"{claim.DateOfClaim}\t" +
                //    $"{claim.IsValid}"));
                String s = String.Format("{0, -10} {1, -10} {2, -15} {3, -10}\n\n", "ID", "Type", "Description", "Ammount");
                s += String.Format("{0, -10} {1, -10} {2, -15} {3, -10}\n", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmmount);
                Console.WriteLine($"\n{s}");
            }

            Console.ReadKey();
        }
        public void SeedContent()
        {
            DateTime claimDay = new DateTime(2000, 11, 11);
            DateTime incidentDay = new DateTime(2000, 11, 11);
            Claim claim1 = new Claim(1, ClaimType.Car, "Car broken", 400, incidentDay, claimDay);
            _repo.AddClaim(claim1);
        }
    }
}
