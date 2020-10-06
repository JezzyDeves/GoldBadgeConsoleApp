using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_CompanyRepository
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert };
    public class Outing
    {
        public EventType TypeOfEvent { get; set; }
        public int People { get; set; }
        public DateTime Date { get; set; }
        public double CostPerson { get; set; }
        public double CostTotal { get; set; }

        public Outing()
        {

        }
        public Outing(EventType type, int people, DateTime date, double personCost, double totalCost)
        {
            TypeOfEvent = type;
            People = people;
            Date = date;
            CostPerson = personCost;
            CostTotal = totalCost;
        }
    }
}
