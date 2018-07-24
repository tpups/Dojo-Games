using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace DojoQuest.Models
{
    public class ValidPlayer
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage="Pick a username")]
        public string Username { get; set; }
        [Required(ErrorMessage="Pick a password")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string Confirm_Password { get; set; }
        [Required(ErrorMessage="Pick a class!")]
        public string Class { get; set; }
    }
}