using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Samurai : Player
    {
        public Samurai()
        {
            Class = "Samurai";
            strength = 35;
            health = 300;
            healthMax = 300;
        }
        public int Attack(Enemies name1)
        {
            Random rand = new Random();
            int attack = rand.Next(1 * strength, 3 * strength);
            name1.health = name1.health - attack;
            return attack;
        }
        public void Meditate()
        {
            Random rand = new Random();
            int meditate = rand.Next(5 * strength, 10 * strength);
            health += meditate;
            if(health > 300)
            {
                health = 300;
            }
        }
        public int Smash(Enemies name1)
        {
            Random rand = new Random();
            int smash = rand.Next(4 * strength, 6 * strength);
            name1.health = name1.health - smash;
            return smash;
        }
        public int Death_Blow(Enemies name1)
        {
            Random rand = new Random();
            int death_blow = rand.Next(3 * strength, 8 * strength);
            name1.health = name1.health - death_blow;
            return death_blow;
        }
    }
}