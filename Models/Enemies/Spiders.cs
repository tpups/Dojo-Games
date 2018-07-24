using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Spider : Enemies
    {   
        
        public Spider()
        {
            name = "Spider";
            strength = 15;
            health = 150;
            healthMax = 150;
        }
        public int RandomSpiderAttack(Player name1)
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
                damage = this.Spin_Web(name1);
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
        public int Spin_Web(Player name1)
        {
            Random rand = new Random();
            int spin_web = rand.Next(6 * strength, 8 * strength);
            name1.health = name1.health - spin_web;
            return spin_web;
        }
    }
}