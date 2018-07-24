using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DojoQuest.Models;

namespace DojoQuest.Models
{
    public class Multiplayer
    {
        public int MultiplayerId {get;set;}
        public int PlayerId {get;set;}
        public int EncountersId {get;set;}
        public Player Player {get;set;}
        public Encounters Encounters {get;set;}
    }
}