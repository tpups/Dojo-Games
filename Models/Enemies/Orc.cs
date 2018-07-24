using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Orc : Enemies
    {   
        public Orc()
        {
            name = "Orc";
            strength = 15;
            health = 200;
            healthMax = 200;
        }
        public int RandomOrcAttack(Player name1)
        {
            Random rand = new Random();
            int attack = rand.Next(1,6);
            int damage = 0;
            if(attack == 1)
            {
                damage = this.Attack(name1);
            }
            if(attack == 2)
            {
                damage = this.Club_Bash(name1);
            }
            if(attack == 3)
            {
                damage = this.Attack(name1);
            }
            if(attack == 4)
            {
                damage = this.Attack(name1);
            }
            if(attack == 5)
            {
                damage = this.Attack(name1);
            }
            return damage;
        }
        public int Attack(Player name1)
        {
            Random rand = new Random();
            int attack = rand.Next(3 * strength, 5 * strength);
            name1.health = name1.health - attack;
            return attack;
        }
        public int Club_Bash(Player name1)
        {
            Random rand = new Random();
            int club_bash = rand.Next(7 * strength, 10 * strength);
            name1.health = name1.health - club_bash;
            return club_bash;
        }
    }
}