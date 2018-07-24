using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using DojoQuest.Models;

namespace DojoQuest.Models
{
    public class Story
    {
        [Key]
        public int StoryId { get; set; }
        public string storyBook { get; set; }
        public DateTime created_at { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public int flag {get;set;}
    }
}