using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Ninja : Player
    {
        
        public Ninja()
        {
            Class = "Ninja";
            dexterity = 35;
            health = 250;
            healthMax = 250;
        }
        public int Attack(Enemies name1)
        {
            Random rand = new Random();
            int attack = rand.Next(1 * dexterity, 3 * dexterity);
            name1.health = name1.health - attack;
            return attack;
        }
        public void Hide()//heal
        {
            Random rand = new Random();
            int Hide_Heal = rand.Next(5 * dexterity, 10 * dexterity);
            health += Hide_Heal;
            if(health > 250)
            {
                health = 250;
            }
        }
        public int Backstab(Enemies name1)
        {
            Random rand = new Random();
            int Back_stab = rand.Next(3 * dexterity, 7 * dexterity);
            name1.health = name1.health - Back_stab;
            return Back_stab;
        }
        public int Rend(Enemies name1)
        {
            Random rand = new Random();
            int rend = rand.Next(4 * dexterity, 5 * dexterity);
            name1.health = name1.health - rend;
            return rend;
        }
    }
}