using Microsoft.EntityFrameworkCore;


namespace DojoQuest.Models
{
    public class DojoContext : DbContext
    {
        public DbSet<Player> player {get; set;}
        public DbSet<Multiplayer> multiplayer {get; set;}
        public DbSet<Encounters> encounters {get;set;}
        public DbSet<Enemies> enemies {get;set;}
        public DbSet<Story> storyline { get; set; }
        public DbSet<Mage> mage{get;set;}
        public DbSet<Hunter> hunter{get;set;}
        public DbSet<Ninja> ninja{get;set;}
        public DbSet<Samurai> samurai {get; set; }
        public DbSet<Priest> priest { get; set; }
        public DbSet<Spider> spider { get; set; }
        public DbSet<Zombie> zombie { get; set; }
        public DbSet<Orc> orc { get; set; }
        public DbSet<Dragon> dragon { get; set; }
        

        // base() calls the parent class' constructor passing the "options" parameter along
        public DojoContext(DbContextOptions<DojoContext> options) : base(options) { }
    }
}