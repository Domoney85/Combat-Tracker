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
        public int CalculateRoll(int skill, int perception, int will, int wound, bool isAssit)
        {
            ConcurrentDictionary<int, int> rolls = new ConcurrentDictionary<int, int>();

            // rolls dice
            for (int i = 0; i < skill; i++)
            {
                int roll = TrackerUtils.RandomNumber(0, 6) + 1;
                rolls.AddOrUpdate(roll, 1, (key, count) => count + 1);
            }

            int maxRoll = rolls.Keys.Max();

            // gives the roll if it was a 6
            if (maxRoll == 6)
            {
                return maxRoll + (rolls[maxRoll] - 1) + perception - wound;
            }
            else if (maxRoll == 1)
            {
                //make a will check 4 or higher
                for (int i = 0; i < 2; i++)
                {
                    if ((TrackerUtils.RandomNumber(0, 6) + 1) >= 4)
                    {
                        return 1;
                    }
                }
                return 0;
            }
            else
            {
                int finalRoll = maxRoll + perception;
                if (finalRoll < 1)
                {
                    return 1;
                }
                return finalRoll;
            }

            // gives the roll if it had assist.
            /*
                if (IsAssist)
                {
                int assist = 0;
                for (int i = 2; i <= Rolls[maxRoll]; i++)
                {
                    if (IsPowerOfTwo(i))
                    {
                        Console.WriteLine(i);
                        assist++;
                    }
                }
                return maxRoll + assist + Bonus;
            }*/

            // gives the base roll calculation.


        }

        //public void SetCombatRoll()
        //{
        //    int sixes = 0;
        //    int answer = 0;
        //    int[] DiceBlock = new int[Skill];
        //    if (Skill == 0) DiceBlock = new int[2];
        //    if (assist == false)
        //    
        //        for (int i = 0; i < DiceBlock.Length; i++)
        //        {
        //            DiceBlock[i] = rnd.Next(1, 7);
        //        }
        //    }
        //    foreach (int x in DiceBlock)
        //    {
        //        if (Skill != 0)
        //        {
        //            if (x == 6)
        //            {
        //                answer = 5;
        //                sixes++;
        //            }
        //            else if (x > answer & x != 6)
        //            {
        //                answer = x;
        //            }
        //        }
        //        else
        //        {
        //            if (x <= answer || answer == 0)
        //            { answer = x; }
        //        }
        //    }
        //    answer += sixes;
        //    CombatRoll = answer + Perception + (Complexity / 10) - Wounds;
        //}
    }
}
