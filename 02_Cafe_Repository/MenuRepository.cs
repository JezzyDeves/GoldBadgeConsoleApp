using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Cafe_Repository
{
    public class MenuRepository
    {
        private readonly List<Menu> _menu = new List<Menu>();

        public bool AddMenuItem(Menu item)
        {
            int startCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > startCount) ? true : false;
            return wasAdded;
        }
        public bool DeleteMenuItem(Menu item)
        {
            bool deleteResult = _menu.Remove(item);
            return deleteResult;
        }
        public List<Menu> GetMenuItems()
        {
            return _menu;
        }
    }
}
