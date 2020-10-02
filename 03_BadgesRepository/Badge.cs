using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_BadgesRepository
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> BadgeDoors { get; set; }
        public Badge()
        {

        }
        public Badge(List<string> doors, int id)
        {
            doors = BadgeDoors;
            id = BadgeID;
        }
    }
}
