using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Tracker
{
    class NameGenerator
    {
        ConcurrentDictionary<string, int> rolls = new ConcurrentDictionary<string, int>();

        public string nameValidation(string name)
        {
            rolls.AddOrUpdate(name, 1, (key, count) => count + 1);
            if (rolls.TryGetValue(name, out int v) && v > 1)
            {
                return name + " " + v;
            }
            return name;
        }
    }
}
