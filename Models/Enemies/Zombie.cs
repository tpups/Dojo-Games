using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Zombie : Enemies
    {   
        
        public Zombie()
        { 
            name = "Zombie";
            strength = 15;
            health = 100;
            healthMax = 100;
        }
        public int RandomZombieAttack(Player name1)
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
                damage = this.Bite(name1);
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
            int attack = rand.Next(3 * strength, 6 * strength);
            name1.health = name1.health - attack;
            return attack;
        }
        public int Bite(Player name1)
        {
            Random rand = new Random();
            int bite = rand.Next(7 * strength, 10 * strength);
            name1.health = name1.health - bite;
            return bite;
        }
    }
}