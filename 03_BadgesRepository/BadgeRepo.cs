using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, List<string>> _badges = new Dictionary<int, List<string>>();

        public bool AddBadge(Badge badge)
        {
            int id = badge.BadgeID;
            List<string> doors = badge.BadgeDoors;

            _badges.Add(id, doors);
            bool added = _badges.ContainsKey(id);
            return added;
        }

        public bool AddBadgeDoors(int id, string newDoor)
        {
            //id = badge.BadgeID;
            //List<string> doors = badge.BadgeDoors;

            //_badges[id].Add(newDoor);
            //bool added = doors.Contains(newDoor);
            //return added;

            foreach(KeyValuePair<int, List<string>> valuePair in _badges)
            {
                if(id == valuePair.Key)
                {
                    valuePair.Value.Add(newDoor);
                    return true;
                }
            }
            return false;
        }
    }
}
