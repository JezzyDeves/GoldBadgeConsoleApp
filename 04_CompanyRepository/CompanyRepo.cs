using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyRepository
{
    public class CompanyRepo
    {
        List<Outing> _repo = new List<Outing>();

        public bool AddOuting(Outing outing)
        {
            int startCount = _repo.Count;
            _repo.Add(outing);
            bool wasAdded = (_repo.Count > startCount) ? true : false;
            return wasAdded;
        }
        public List<Outing> GetOutings()
        {
            return _repo;
        }
        public void Test()
        {
            int y = 0;
            int x = 15;
            y = y + x;
        }
        public double TotalCost()
        {
            double total = 0;
            foreach(Outing outing in _repo)
            {
                total += outing.CostTotal;
            }
            return total;
        }
        public double GetCostByType(EventType type)
        {
            double result = 0;
            foreach (Outing outing in _repo)
            {
                if (outing.TypeOfEvent == type)
                {
                    result += outing.CostTotal;
                }
            }
            return result;
        }
    }
}
