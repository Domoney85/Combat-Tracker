using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using RandomNameGenerator;
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
            if (string.Empty.Equals(name))
                name = generateRandomName();

            rolls.AddOrUpdate(name, 1, (key, count) => count + 1);
            if (rolls.TryGetValue(name, out int v) && v > 1)
            {
                return string.Format("{0}({1})", name, v);
            }
            return name;
        }

        private string generateRandomName()
        {
            return RandomNameGenerator.NameGenerator.GenerateFirstName(TrackerUtils.RandomGender());

        }
    }
}
