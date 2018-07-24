using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DojoQuest.Models;

namespace DojoQuest.Models
{
    public class Enemies
    {
        public int EnemiesId { get; set; }
        public string name{get;set;}
        public int health { get; set; }
        public int healthMax { get; set; }
        public int strength { get; set; }
        public int EncountersId{get;set;}
        public bool life{get;set;}= true;
        public Encounters Encounters { get; set; }

    public Enemies()
        {
            strength= 20;
            health = 100;
            healthMax = 100;
        }
    public Enemies(int NewStrength, int NewHealth)
        {
            strength = NewStrength;
            health = NewHealth;
        }
    }
}