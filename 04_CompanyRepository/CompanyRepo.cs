﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyRepository
{
    public class CompanyRepo
    {
        private readonly List<Outing> _repo = new List<Outing>();

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
        public double TotalCost()
        {
            foreach(Outing outing in _repo)
            {
                double cost = outing.CostTotal;
                double total = 0;
                double add = total + cost;
                return add;
            }
            double result = 0;
            return result;
        }
    }
}
