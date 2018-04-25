using System;

namespace Combat_Tracker
{
    class Character
    {
        public static Random rnd = new Random();

        public bool IsDown { get; set; }
        public bool InCombat { get; set; }
        public int Wounds { get; set; }
        public int CombatRoll { get; set; }

        public int ID { get; private set; }
        public String Name { get; private set; }
        public int Skill { get; private set; }
        public int Complexity { get; private set; }
        public int Perception { get; private set; }
        public int Will { get; private set; }
        public bool Assist { get; private set; }

        public Character(int id, String n, int sk, int cpx, int p, int w)
        {
            ID = id;
            Name = n;
            Skill = sk;
            Complexity = cpx;
            Perception = p;
            Will = w;
            Wounds = 0;
            Assist = false;
        }

        public void ApplyWounds(int x)
        {
            Wounds = x;
        }
    }

}
