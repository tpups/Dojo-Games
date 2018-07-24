using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoQuest.Models
{
    public class Mage : Player
    {
        public Mage()
        {
            Class = "Mage";
            intelligence = 35;
            health = 250;
            healthMax = 250;
        }
        public int Attack(Enemies name1)
        {
            Random rand = new Random();
            int attack = rand.Next(1 * intelligence, 3 * intelligence);
            name1.health = name1.health - attack;
            return attack;
        }
        public void Heal()
        {
            Random rand = new Random();
            int light_heal = rand.Next(5 * intelligence, 10 * intelligence);
            health += light_heal;
            if(health > 250)
            {
                health = 250;
            }
        }
        public int Fireball(Enemies name1)
        {
            Random rand = new Random();
            int fireball = rand.Next(2 * intelligence, 8 * intelligence);
            name1.health = name1.health - fireball;
            return fireball;
        }
        public int FrostBolt(Enemies name1)
        {
            Random rand = new Random();
            int Frost_Boil = rand.Next(4 * intelligence, 6 * intelligence);
            name1.health = name1.health - Frost_Boil;
            return Frost_Boil;
        }
    }
}