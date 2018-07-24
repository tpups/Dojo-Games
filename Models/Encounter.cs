using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DojoQuest.Models;
namespace DojoQuest.Models
{
public class Encounters
    {
        public int EncountersId { get; set; }
        public int PlayerId{get;set;}
        public int spiders { get; set; }
        public int zombies { get; set; }
        public int orcs { get; set; }
        public int dragons { get; set;} 
        public int totalEnemies{ get; set; }
        public Player Player { get; set; }
        List <Multiplayer> MorePlayers { get; set; }
        List<Enemies> FightEnemies { get; set; }

        public Encounters()
        {
            MorePlayers = new List <Multiplayer>();
            FightEnemies = new List <Enemies>();
        } 
    }
}
