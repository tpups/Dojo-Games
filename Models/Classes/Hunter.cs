using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Threading;

namespace DojoQuest.Models
{
    public class Hunter : Player
    {   
        public Hunter()
        {
            Class = "Hunter";
            dexterity = 35;
            health = 270;
            healthMax = 270;
        }
        public int Attack(Enemies name1)
        {
            Random rand = new Random();
            int attack = rand.Next(1 * dexterity, 3 * dexterity);
            name1.health = name1.health - attack;
            return attack;
        }
        public void Mend()//heal
        {
            Random rand = new Random();
            int mend = rand.Next(3* dexterity, 6 * dexterity);
            health += mend;
            if(health > 270)
            {
                health = 270;
            }
        }
        public int Snipe(Enemies name1)
        {
            Random rand = new Random();
            int snipe = rand.Next(2 * dexterity, 10 * dexterity);
            name1.health = name1.health - snipe;
            return snipe;
        }
        public int Silencing_Shot(Enemies name1)
        {
            Random rand = new Random();
            int silencing_shot = rand.Next(3 * dexterity, 5 * dexterity);
            name1.health = name1.health - silencing_shot;
            return silencing_shot;
        }
    }
}