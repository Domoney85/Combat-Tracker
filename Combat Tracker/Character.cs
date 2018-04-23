using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Tracker
{
    class Character
    {
        public static Random rnd = new Random();

        public bool IsDown { get; set; }
        public bool InCombat { get; set; }
        public int Wounds { get; set; }
        public double CombatStep { get; set; }

        public int ID { get; private set; }
        public String Name { get; private set; }
        public String RName { get; private set; } // TODO: better name for this?
        public int Skill { get; private set; }
        public int Complexity { get; private set; }
        public int Perception { get; private set; }
        public int Will { get; private set; }

        private int count;
        private double ocombatStep;
        private bool assist;

        public Character(int id, String n, int sk, int cpx, int p, int w)
        {
            ID = id;
            Name = RName = n;
            Skill = sk;
            Complexity = cpx;
            Perception = p;
            Will = w;
            Wounds = 0;
            assist = false;
        }

        /// <summary>
        /// Handles duplicate name generation
        /// probably a better way to play with this.
        /// </summary>
        public void SetCount()
        {
            ++count;
            if (count > 1)
            {
                Name = RName + " " + count.ToString();
            }
            else
            {
                Name = RName;
            }
        }

        public void SetCombatStep()
        {
            int sixes = 0;
            int answer = 0;
            int[] DiceBlock = new int[Skill];
            if (Skill == 0) DiceBlock = new int[2];
            if (assist == false)
            {

                for (int i = 0; i < DiceBlock.Length; i++)
                {

                    DiceBlock[i] = rnd.Next(1, 7);
                }
            }
            foreach (int x in DiceBlock)
            {
                if (Skill != 0)
                {
                    if (x == 6)
                    {
                        answer = 5;
                        sixes++;
                    }
                    else if (x > answer & x != 6)
                    {
                        answer = x;
                    }
                }
                else
                {
                    if (x <= answer || answer == 0)
                    { answer = x; }
                }

            }
            answer += sixes;
            CombatStep = answer + Perception + (Complexity / 10) - Wounds;
            ocombatStep = answer + Perception + (Complexity / 10);
        }

        public void ApplyWounds(int x)
        {
            Wounds = x;
            CombatStep = ocombatStep - Wounds;
        }

        public void BumpUp()
        {
            ++CombatStep;
        }

        public void BumpDown()
        {
            --CombatStep;
        }
    }

}
