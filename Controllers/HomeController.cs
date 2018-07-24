using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoQuest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DojoQuest.Controllers
{
    public class HomeController : Controller
    {
        public void SetTemp(int tempVal)
        {

            int temp = (int)HttpContext.Session.GetInt32("temp");
            temp += tempVal;
            HttpContext.Session.SetInt32("temp",(int)temp);
            int tempPercent = (int)(((float)temp / 200) * 100);
            ViewBag.tempPercent = tempPercent;
            ViewBag.temp = temp;
            int Id = (int)HttpContext.Session.GetInt32("PlayerId");
            Player Player1 = _context.player.SingleOrDefault(p => p.PlayerId == Id);
            float health = (float)Player1.health;
            float healthMax = (float)Player1.healthMax;
            int healthPercent = (int)(health / healthMax * 100);
            ViewBag.health = (int)health;
            ViewBag.healthPercent = healthPercent;
            ViewBag.healthMax = (int)healthMax;
            List<Story> story = _context.storyline.Where(p => p.PlayerId == Id).OrderByDescending(s => s.created_at).ToList();
            ViewBag.story = story;
        }
        
        private DojoContext _context;

        public HomeController(DojoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int? Id = HttpContext.Session.GetInt32("PlayerId");
            if(Id != null)
            {
                ViewBag.start = true;
                return View();
            }
            return RedirectToAction("Login");
        }   
        [Route("Registration")]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ValidPlayer Player1)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<ValidPlayer> Hasher = new PasswordHasher<ValidPlayer>();
                Player1.Password = Hasher.HashPassword(Player1, Player1.Password);
                Mage newMage = new Mage();
                Hunter newHunter = new Hunter();
                Priest newPriest = new Priest();
                Ninja newNinja = new Ninja();
                Samurai newSamurai = new Samurai();
                if(Player1.Class == "mage")
                {
                    newMage.Username = Player1.Username;
                    newMage.Password = Player1.Password;
                    newMage.Class = Player1.Class;
                    _context.Add(newMage);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("PlayerId", newMage.PlayerId);
                }
                if(Player1.Class == "priest")
                {
                    newPriest.Username = Player1.Username;
                    newPriest.Password = Player1.Password;
                    newPriest.Class = Player1.Class;
                    _context.Add(newPriest);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("PlayerId", newPriest.PlayerId); 
                }
                
                if(Player1.Class == "hunter")
                {
                    newHunter.Username = Player1.Username;
                    newHunter.Password = Player1.Password;
                    newHunter.Class = Player1.Class;
                    _context.Add(newHunter);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("PlayerId", newHunter.PlayerId);
                }
                
                if(Player1.Class == "ninja")
                {
                    newNinja.Username = Player1.Username;
                    newNinja.Password = Player1.Password;
                    newNinja.Class = Player1.Class;
                    _context.Add(newNinja);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("PlayerId", newNinja.PlayerId);               
                }
                
                if(Player1.Class == "samurai")
                {
                    newSamurai.Username = Player1.Username;
                    newSamurai.Password = Player1.Password;
                    newSamurai.Class = Player1.Class;
                    _context.Add(newSamurai);
                    _context.SaveChanges();
                    HttpContext.Session.SetInt32("PlayerId", newSamurai.PlayerId);
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Registration");
        }
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PlayerLogin(Player Player1)
        {
            var username = _context.player.SingleOrDefault(e => e.Username == Player1.Username);
            if(username != null && Player1.Password != null)
            {
                var Hasher = new PasswordHasher<Player>();
                // Pass the user object, the hashed password, and the PasswordToCheck
                if(0 != Hasher.VerifyHashedPassword(username, username.Password, Player1.Password))
                {
                    HttpContext.Session.SetInt32("PlayerId", username.PlayerId);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.message = "User Name and Password does not match.";
            return View("Login");
        }
    [Route("startgame")]    
    public IActionResult StartGame()
        {
            HttpContext.Session.SetInt32("temp", 200);
            SetTemp(0);
            HttpContext.Session.SetInt32("Level", 1);
            int Id = (int)HttpContext.Session.GetInt32("PlayerId");
            Player Player1 = _context.player.SingleOrDefault(p => p.PlayerId == Id);
            Player1.health = Player1.healthMax;
            List<Story> story = _context.storyline.Where(p => p.PlayerId == Id).ToList();
            foreach(var thing in story)
            {
                _context.Remove(thing);
            }
            _context.SaveChanges();
            return RedirectToAction("firstEncounter");
        }
    public IActionResult firstEncounter(Player Player1)
        {
            int playerId = (int)HttpContext.Session.GetInt32("PlayerId");
            int? Level = HttpContext.Session.GetInt32("Level");
            if(Level == 4)
            {
                return RedirectToAction("GameOver");
            }
            Story newStory = new Story();
            Story newStory2 = new Story();
            List<Enemies> enemy = new List<Enemies>();
            if(Level == 1)
            {
                newStory.storyBook = "On a hot summer day at the Dojo..........The Dojo's AC, which is on the top floor, was destroyed by the Summer Dragon God";
                newStory2.storyBook = "2 Spiders  2 Zombies and 1 Orc Spawned. You have to take them down before they take you down. heh GOOD LUCK!!!!!";
                newStory.created_at = DateTime.Now;
                newStory2.created_at = DateTime.Now;
                newStory.PlayerId = playerId;
                newStory2.PlayerId = playerId;
                newStory.flag = 1;
                newStory2.flag = 1;                                
                _context.Add(newStory2);
                _context.SaveChanges();
            }
            else if (Level == 2)
            {
                newStory.storyBook = "Climbed the stairs to the Second Floor as the temperature continues to rise. ";
                newStory2.storyBook = "4 Spiders  4 Zombies and 2 Orc Spawned. You have to take them down before they take you down. heh GOOD LUCK!!!!!";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = playerId;
                newStory2.created_at= DateTime.Now;
                newStory2.PlayerId = playerId;
                newStory.flag = 1;
                newStory2.flag = 1;
                SetTemp(30);
                _context.Add(newStory2);                
            }
            else if (Level == 3)
            {
                newStory.storyBook = "You have reached the third floor. You hear the sound of ping pong balls being smashed. You resist the temptation. The Summer Dragon God appears.......He looks angry. ";
                SetTemp(50);
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = playerId;
                newStory.flag = 1;
            }
            _context.Add(newStory);
            if(Level == 3)
            {
                Encounters bossEcounter = new Encounters();
                bossEcounter.PlayerId = playerId;
                bossEcounter.dragons = 1;
                bossEcounter.totalEnemies++;
                _context.Add(bossEcounter);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("EncounterId", bossEcounter.EncountersId);
                Dragon newDragon = new Dragon();
                newDragon.EncountersId = bossEcounter.EncountersId;
                _context.Add(newDragon);
                _context.SaveChanges();
            }
            else
            {
                Encounters newEcounter = new Encounters();
                newEcounter.PlayerId = playerId;
                newEcounter.spiders = 2 * (int)Level;
                newEcounter.zombies = 2 * (int)Level;
                newEcounter.orcs = 1 * (int)Level;
                newEcounter.totalEnemies = newEcounter.spiders + newEcounter.zombies + newEcounter.orcs;
                _context.Add(newEcounter);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("EncounterId", newEcounter.EncountersId);
                for(var i = 0; i< newEcounter.spiders;i++)
                {       
                    Zombie newZomb = new Zombie();
                    newZomb.EncountersId = newEcounter.EncountersId;
                    Spider newSpid = new Spider();
                    newSpid.EncountersId = newEcounter.EncountersId;
                    _context.Add(newZomb);
                    _context.Add(newSpid);
                    _context.SaveChanges();
                }
                for(var i = 0; i< newEcounter.orcs;i++)
                {
                    Orc newOrc = new Orc();
                    newOrc.EncountersId = newEcounter.EncountersId;
                    _context.Add(newOrc);
                }
                }
                HttpContext.Session.SetObjectAsJson("Enemies", enemy);
                _context.SaveChanges();
                return RedirectToAction("Moves");
            }
        public IActionResult Moves()
        {
            int PlayerId = (int)HttpContext.Session.GetInt32("PlayerId");
            Player Player1 = _context.player.SingleOrDefault(p => p.PlayerId == PlayerId);
            List<string> moves = new List<string>();
            if(Player1.Class == "mage")
            {
                moves.Add("Attack");
                moves.Add("Heal");
                moves.Add("Fireball");
                moves.Add("FrostBolt");
            }
            if(Player1.Class == "samurai")
            {
                moves.Add("Attack");
                moves.Add("Meditate");
                moves.Add("Smash");
                moves.Add("Death Blow");
            }
            if(Player1.Class == "hunter")
            {
                moves.Add("Attack");
                moves.Add("Mend");
                moves.Add("Snipe");
                moves.Add("Silencing Shot");
            }
            if(Player1.Class == "ninja")
            {
                moves.Add("Attack");
                moves.Add("Hide");
                moves.Add("Backstab");
                moves.Add("Rend");
            }
            if(Player1.Class == "priest")
            {
                moves.Add("Attack");
                moves.Add("Holy_Heal");
                moves.Add("Holy_Light");
                moves.Add("Smight");
            }
            SetTemp(0);
            ViewBag.moves = moves;
            return View("Index");
            
        }
        [Route("playersturn/{attk}")]
        public IActionResult PlayersTurn(int attk)
        {
            int PlayerId = (int)HttpContext.Session.GetInt32("PlayerId");
            Player Player1 = _context.player.SingleOrDefault(p => p.PlayerId == PlayerId);
            int? enconId = HttpContext.Session.GetInt32("EncounterId");
            Encounters encounter = _context.encounters.SingleOrDefault(e=>e.EncountersId == enconId);
            Enemies monster = _context.enemies.Where(m=>m.EncountersId == enconId && m.life==true).First();
            Story newStory = new Story();
            Story newStory2 = new Story();
            if(Player1.Class == "mage")
            {   
                Mage Player = _context.mage.SingleOrDefault(p => p.PlayerId == PlayerId);
                if(attk == 1)
                {
                    int attackVal = Player.Attack(monster);
                    attackVal.ToString();
                    newStory.storyBook = "You attacked a "+ monster.name +" and did "+ attackVal + " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                                                                        
                }
                else if(attk == 2)
                {
                    Player.Heal();
                    newStory.storyBook = "You used heal";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 4;
                }
                else if(attk == 3)
                {
                    int attackVal = Player.Fireball(monster);  
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal+ " damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;                      
                }                
                else if(attk == 4)
                {
                    int attackVal =  Player.FrostBolt(monster);
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal +" damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId; 
                    newStory.flag = 2; 
                }
            }
            if(Player1.Class == "hunter")
            {   
                Hunter Player = _context.hunter.SingleOrDefault(p => p.PlayerId == PlayerId);
                if(attk == 1)
                {
                    int attackVal = Player.Attack(monster);
                    attackVal.ToString();
                    newStory.storyBook = "You attacked a "+ monster.name +" and did "+ attackVal + " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
                else if(attk == 2)
                {
                    Player.Mend(); 
                    newStory.storyBook = "You were mended fight on Hunter.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 4;                                       
                }
                else if(attk == 3)
                {
                    int attackVal = Player.Snipe(monster);  
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal + " damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;  
                    newStory.flag = 2;
                }                
                else if(attk == 4)
                {
                    int attackVal =  Player.Silencing_Shot(monster);
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal+ " damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;  
                }
            }
            if(Player1.Class == "samurai")
            {   
                Samurai Player = _context.samurai.SingleOrDefault(p => p.PlayerId == PlayerId);
                if(attk == 1)
                {
                    int attackVal = Player.Attack(monster);
                    attackVal.ToString();
                    newStory.storyBook = "You attacked a "+ monster.name +" and did "+ attackVal + " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
                else if(attk == 2)
                {
                    Player.Meditate();
                    newStory.storyBook = "You used meditate.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 4;                    
                }
                else if(attk == 3)
                {
                    int attackVal = Player.Smash(monster);  
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal +" damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;  
                }                
                else if(attk == 4)
                {
                    int attackVal =  Player.Death_Blow(monster);
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal+ " damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
            }
            if(Player1.Class == "ninja")
            {   
                Ninja Player = _context.ninja.SingleOrDefault(p => p.PlayerId == PlayerId);
                if(attk == 1)
                {
                    int attackVal = Player.Attack(monster);
                    attackVal.ToString();
                    newStory.storyBook = "You attacked a "+ monster.name +" and did "+ attackVal + " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
                else if(attk == 2)
                {
                    Player.Hide();
                    newStory.storyBook = "You hide from the enemies.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 4;
                }
                else if(attk == 3)
                {
                    int attackVal = Player.Backstab(monster);  
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal+ " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }                
                else if(attk == 4)
                {
                    int attackVal =  Player.Rend(monster);
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal+ " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
            }
            if(Player1.Class == "priest")
            {   
                Priest Player = _context.priest.SingleOrDefault(p => p.PlayerId == PlayerId);
                if(attk == 1)
                {
                    int attackVal = Player.Attack(monster);
                    attackVal.ToString();
                    newStory.storyBook = "You attacked a "+ monster.name +" and did "+ attackVal + " damage.";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
                else if(attk == 2)
                {
                    Player.Holy_Heal();
                    newStory.storyBook = "You healed yourself";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 4;
                }
                else if(attk == 3)
                {
                    int attackVal = Player.Holy_Light(monster);  
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal +" damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }                
                else if(attk == 4)
                {
                    int attackVal =  Player.Smight(monster);
                    newStory.storyBook = "You attacked a "+ monster.name +" for "+ attackVal +" damage";
                    SetTemp(0);
                    newStory.created_at = DateTime.Now;
                    newStory.PlayerId = PlayerId;
                    newStory.flag = 2;
                }
            }
            _context.Add(newStory);
            _context.SaveChanges();
            if(monster.health <= 0)
            {
                monster.health = 0;
                monster.life = false;
                newStory2.storyBook = "You killed a "+ monster.name;
                SetTemp(-10);
                newStory2.created_at = DateTime.Now;
                newStory2.PlayerId = PlayerId;
                newStory2.flag = 2;
                _context.Add(newStory2);
                _context.SaveChanges();
            }
            List<Enemies> enemyCount = _context.enemies.Where(m=>m.EncountersId == enconId && m.life==true).ToList();
            if(enemyCount.Count() > 0)
            {
            return RedirectToAction("EnemiesTurn");
            }
            int level = (int)HttpContext.Session.GetInt32("Level");
            level++;
            HttpContext.Session.SetInt32("Level",level);
            return RedirectToAction("firstEncounter");
        }
        public IActionResult EnemiesTurn()
        {
            int PlayerId = (int)HttpContext.Session.GetInt32("PlayerId");
            Player Player1 = _context.player.SingleOrDefault(p => p.PlayerId == PlayerId);
            int? enconId = HttpContext.Session.GetInt32("EncounterId");
            Enemies monster = _context.enemies.Where(m=>m.EncountersId == enconId && m.life==true).First();
            
            Story newStory = new Story();
            if(monster.name =="Spider")
            {
                Spider spider = _context.spider.Where(m=>m.EncountersId == enconId && m.life==true).First();
                int spideratt = spider.RandomSpiderAttack(Player1);
                newStory.storyBook = "You were attacked by " + monster.name + " for " + spideratt + " damage";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = PlayerId;
                newStory.flag = 3;
            }
            else if(monster.name =="Zombie")
            {
                Zombie zombie= _context.zombie.Where(m=>m.EncountersId == enconId && m.life==true).First();
                int zombireatt = zombie.RandomZombieAttack(Player1);
                newStory.storyBook = "You were attacked by " + monster.name + " for " + zombireatt + " damage";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = PlayerId;
                newStory.flag = 3;
            }
            else if(monster.name =="Orc")
            {
                Orc orc = _context.orc.Where(m=>m.EncountersId == enconId && m.life==true).First();
                int orcatt = orc.RandomOrcAttack(Player1);
                newStory.storyBook = "You were attacked by " + monster.name + " for " + orcatt + " damage";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = PlayerId;
                newStory.flag = 3;
            }
            else if(monster.name =="Dragon")
            {                
                Dragon dragon = _context.dragon.Where(m=>m.EncountersId == enconId && m.life==true).First();
                int dragonatt = dragon.RandomDragonAttack(Player1);
                newStory.storyBook = "You were attacked by " + monster.name + " for " + dragonatt + " damage";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = PlayerId;
                newStory.flag = 3;
            }
            
            if(Player1.health <=0)
            {
                Player1.health = 0;
                Player1.life = false;
                _context.Add(newStory);
                _context.SaveChanges();
                return RedirectToAction("GameOver");                                    
            }
            
            SetTemp(0);
            _context.Add(newStory);
            _context.SaveChanges();
            return RedirectToAction("Moves");
        }
        public IActionResult GameOver()
        {   
            int PlayerId = (int)HttpContext.Session.GetInt32("PlayerId");
            Player Player1 = _context.player.SingleOrDefault(p => p.PlayerId == PlayerId);
            Story newStory = new Story();
            if(Player1.health == 0)
            {
                newStory.storyBook = "You Lose, Game Over!!";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = PlayerId;
                newStory.flag = 5;                
                _context.Add(newStory);
                _context.SaveChanges();
            }
            else
            {
                newStory.storyBook = "You made that Dragon Your Bitch! Cool air emerges from the vents in the ceiling.";
                newStory.created_at = DateTime.Now;
                newStory.PlayerId = PlayerId;
                newStory.flag = 6;                
                HttpContext.Session.SetInt32("temp",70);
                SetTemp(0);
                _context.Add(newStory);                
                _context.SaveChanges();
            }
            SetTemp(0);
            return View("Index");
            
        }
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }
    }
    public static class SessionExtensions
    {
        // We can call ".SetObjectAsJson" just like our other session set methods, by passing a key and a value
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            // This helper function simply serializes theobject to JSON and stores it as a string in session
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type we specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
