using NLog;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Tracker
{
    class Roller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int CalculateRoll(int skill, int perception, int will, int wound, bool isAssit, string name)
        {
            ConcurrentDictionary<int, int> rolls = rollDice(skill);

            int maxRoll = rolls.Keys.Max();

            // gives the roll if it was a 6
            if (maxRoll == 6)
            {
                logger.Info("{} rolled {} with {} perception and {} to wounds.", name, rolls, perception, wound);
                return maxRoll + (rolls[maxRoll] - 1) + perception - wound;
            }
            else if (maxRoll == 1)
            {
                logger.Info("{} glitched with {}", name, rolls);
                //make a will check 4 or higher
                for (int i = 0; i < 2; i++)
                {
                    if ((TrackerUtils.RandomNumber(0, 6) + 1 + will) >= 4)
                    {
                        logger.Info("{} saved their will check", name);
                        return 1;
                    }
                }
                // gitch and removes them from combat
                logger.Info("{} failed their will check.", name);
                return 0;
            }
            else
            {
                int finalRoll = maxRoll + perception;
                if (finalRoll < 1)
                {
                    logger.Info("{} rolled and adjusted {}", name, 1);
                    return 1;
                }
                logger.Info("{} rolled {}", name, finalRoll);
                return finalRoll;
            }
        }

        /**
         * Rolls a number of dice based on the number passed in
         * 
         * returns a dictionary with the number rolled as the key and 
         * how many times it was rolled as the value.
         */
        private ConcurrentDictionary<int, int> rollDice(int skill)
        {
            ConcurrentDictionary<int, int> rolls = new ConcurrentDictionary<int, int>();

            // rolls dice
            for (int i = 0; i < skill; i++)
            {
                int roll = TrackerUtils.RandomNumber(0, 6) + 1;
                rolls.AddOrUpdate(roll, 1, (key, count) => count + 1);
            }

            return rolls;
        }
    }
}
