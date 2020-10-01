﻿using ClaimsRepository;
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
                        HandleClaim();
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

            foreach(Claim claim in claims)
            {
                String s = String.Format("{0, -10} {1, -10} {2, -15} {3, -10} {4, -25} {5, -25} {6, -25}\n\n", "ID", "Type", "Description", "Ammount", "Incident Date", "Claim Date", "Valid");
                s += String.Format("{0, -10} {1, -10} {2, -15} {3, -10} {4, -25} {5, -25} {6, -35}\n", claim.ClaimID, claim.TypeOfClaim, claim.Description, claim.ClaimAmmount, claim.DateOfIncident, claim.DateOfClaim, claim.IsValid);
                Console.WriteLine($"\n{s}");
                string end = new String('-', 120);
                Console.WriteLine(end);
            }

            Console.ReadKey();
        }
        public void HandleClaim()
        {
            List<Claim> claims = _repo.GetAllClaims();
            bool getNextItem = true;

            while (getNextItem)
            {
                Console.WriteLine($"ID: {claims[0].ClaimID}");
                Console.WriteLine($"Type: {claims[0].TypeOfClaim}");
                Console.WriteLine($"Description: {claims[0].Description}");
                Console.WriteLine($"Ammount: {claims[0].ClaimAmmount}");
                Console.WriteLine($"Date of incident:{claims[0].DateOfIncident}");
                Console.WriteLine($"Date of claim: {claims[0].DateOfClaim}");
                Console.WriteLine($"Valid: {claims[0].IsValid}");

                Console.WriteLine("Do you want to handle this claim y or n?");
                string input = Console.ReadLine();
                if(input == "y")
                {
                    _repo.RemoveClaim(claims[0]);
                }
                else
                {
                    getNextItem = false;
                }
            }
        }
        public void SeedContent()
        {
            DateTime claimDay = new DateTime(2000, 11, 11);
            DateTime incidentDay = new DateTime(2000, 11, 11);
            Claim claim1 = new Claim(1, ClaimType.Car, "Car broken", 400, incidentDay, claimDay);

            DateTime claimDay2 = new DateTime(2005, 11, 11);
            DateTime incidentDay2 = new DateTime(2005, 10, 11);
            Claim claim2 = new Claim(2, ClaimType.Home, "Fire", 12000, incidentDay2, claimDay2);
            _repo.AddClaim(claim1);
            _repo.AddClaim(claim2);
        }
    }
}
