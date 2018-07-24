using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoQuest.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Class { get; set; }
        public int strength { get; set; } 
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int health { get; set; }
        public int healthMax { get; set; }
        public bool life { get; set; } = true;
        List<Encounters> Fights { get; set; }
        List<Story> Stories { get; set; }


    
        public Player()
        {
            strength= 20;
            intelligence = 20;
            dexterity = 20;
            health = 100;
            healthMax = 100;
            List<Encounters> Fights = new List<Encounters>();
            List<Story> Stories = new List<Story>();
        }
        
        public Player(int NewStrength, int NewIntel, int NewDex, int NewHealth)
        {
            strength = NewStrength;
            intelligence = NewIntel;
            dexterity = NewDex;
            health = NewHealth;
        }
    }
}