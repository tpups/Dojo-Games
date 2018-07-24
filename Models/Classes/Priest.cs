using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Priest : Player
    {
        
        public Priest()
        {
            Class = "Priest";
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
        public void Holy_Heal()//heal
        {
            Random rand = new Random();
            int holy_heal = rand.Next(7 * intelligence, 12 * intelligence);
            health += holy_heal;
            if(health > 250)
            {
                health = 250;
            }
        }
        public int Holy_Light(Enemies name1)
        {
            Random rand = new Random();
            int holy_light = rand.Next(2 * intelligence, 6 * intelligence);
            name1.health = name1.health - holy_light;
            return holy_light;
        }
        public int Smight(Enemies name1)
        {
            Random rand = new Random();
            int smight = rand.Next(3 * intelligence, 5 * intelligence);
            name1.health = name1.health - smight;
            return smight;
        }
    }
}