using EFLib.Models;
using Microsoft.EntityFrameworkCore;

namespace EFLib
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            // Ensure that the database its created 
            Database.EnsureCreated();
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           /* // adding a composite primary key between TeamId and LeagueId
            modelBuilder.Entity<LeagueHasTeams>()
                .HasKey(k => new {k.TeamId, k.LeagueId});
            
            // one to many Team -> LeagueHasTeams
            modelBuilder.Entity<LeagueHasTeams>()
                .HasOne(lht => lht.Team)
                .WithMany(t => t.LeagueHasTeamsList);
            
            // one to many League -> LeagueHasTeams 
            modelBuilder.Entity<LeagueHasTeams>()
                .HasOne(lht => lht.League)
                .WithMany(l => l.LeagueHasTeamsList);
            base.OnModelCreating(modelBuilder);*/
            

        }
    }
}