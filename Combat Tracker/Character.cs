using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combat_Tracker
{
    class Character
    {
        private String name;
        private int csSkill;
        private int csCPX;
        private int perAtt;
        private int willAtt;
        private int misc;
        private int wounds;
        private double ocombatStep;
        private String rName;
        private int count;
        private bool isDown;
        public static Random rnd = new Random();

        private double combatStep;
        private bool assist = false;

       

        public Character(String n, int sk, int cpx, int p, int w, int m, int wo)
        {
            name = n;
            rName = n;
           csSkill = sk;
            csCPX = cpx;
            perAtt = p;
            willAtt = w;
            misc = m;
            wounds = wo;
            
        }
        public Character(String n, int sk, int cpx,int p,int w)
        {
            name = n;
            rName = n;
            csSkill = sk;
            csCPX = cpx;
            perAtt = p;
            willAtt = w;
            misc = 0;
            wounds = 0;
        }
        public Character(String n)
        {
            name = n;
            rName = n;
            csSkill = 0;
            csCPX = 0;
            perAtt = 0;
            willAtt = 0;
            misc = 0;
            wounds = 0;
        }

        public String getName()
        {
            return name;
        }
        public String getrName()
        {
            return rName;
        }
        public int getSkill()
        {
            return csSkill;
        }
        public int getCPX()
        {
            return csCPX;
        }
        public int getPer()
        {
            return perAtt;
        }
        public int getWill()
        {
            return willAtt;
        }
        public void setDown(Boolean x)
        {
            isDown = x;
        }
        public Boolean getDown()
        {
            return isDown;
        }
        public void setWound(int wo)
        {
            wounds = wo;
        }
        public void SetCount()
        {
            ++count;
            if (count >1)
            {
                name = rName+" "+count.ToString();
            }
            else
            {
                name = rName;
            }
        }
        public void SetCombatStep()
        {
            int sixes = 0;
            int answer = 0;
            int[]DiceBlock = new int[csSkill];

            if (csSkill == 0) DiceBlock = new int[2];
            
            if (assist == false)
            {

                for (int i = 0; i < DiceBlock.Length; i++)
                {
                    
                    DiceBlock[i] = rnd.Next(1, 7); 
                }
            }
            foreach (int x in DiceBlock)
            {
                if (csSkill != 0)
                {
                    if (x == 6)
                    {
                        answer = 5;
                        sixes++;
                    }
                    else if (x > answer)
                    {
                        answer = x;
                    }
                }
                else
                {
                    if(x <= answer || answer ==0)
                    { answer = x; }
                }
                answer += sixes;
                this.combatStep = answer + perAtt + (csCPX / 10)- wounds;
                this.ocombatStep = answer + perAtt + (csCPX / 10);
            }
        }
        public void ApplyWounds(int x)
        {
            wounds = x;
            combatStep = ocombatStep - wounds;
        }
        public void bumpUp()
        {
            ++combatStep;
        }
        public void bumpDown()
        {
            --combatStep;
        }
        public void SetCombatStep(double n)
        {
            combatStep = n;
        }
        public double getCombatStep()
        {
            return combatStep;
        }
    }

}
