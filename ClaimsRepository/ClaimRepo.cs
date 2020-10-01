using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsRepository
{
    public class ClaimRepo
    {
        private readonly List<Claim> _claims = new List<Claim>();

        public List<Claim> GetAllClaims()
        {
            return _claims;
        }
        public bool AddClaim(Claim claim)
        {
            int startCount = _claims.Count;
            _claims.Add(claim);
            bool wasAdded = (_claims.Count > startCount) ? true : false;
            return wasAdded;
        }
        public bool RemoveClaim(Claim claim)
        {
            bool removed = _claims.Remove(claim);
            return removed;
        }
    }
}
