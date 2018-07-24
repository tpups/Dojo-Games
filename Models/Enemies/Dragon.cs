using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Dragon : Enemies
    {   
        
        public Dragon()
        {
            name = "Dragon";
            strength = 15;
            health = 300;
            healthMax = 300;
        }
        public int RandomDragonAttack(Player name1)
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
                damage = this.FireBreath(name1);
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
            int attack = rand.Next(5 * strength, 9 * strength);
            name1.health = name1.health - attack;
            return attack;
        }
        public int FireBreath(Player name1)
        {
            Random rand = new Random();
            int firebreath = rand.Next(11 * strength, 20 * strength);
            name1.health = name1.health - firebreath;
            return firebreath;
        }
    }
}