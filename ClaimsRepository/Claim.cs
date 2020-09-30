using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public enum ClaimType { Car, Home, Theft}
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType TypeOfClaim { get; set; }
        public string Description { get; set; }
        public double ClaimAmmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid
        {
            get
            {
                var days = (DateOfClaim - DateOfIncident).TotalDays;
                if(days <= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Claim()
        {

        }
        public Claim(int id, ClaimType claimType, string description, double ammount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = id;
            TypeOfClaim = claimType;
            Description = description;
            ClaimAmmount = ammount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
        }
    }
}
