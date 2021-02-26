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
        public virtual DbSet<ActionInMatch> ActionInMatches { get; set; }
        public virtual DbSet<LeagueHasTeams> LeagueHasTeams { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchLog> MatchLogs { get; set; }
        public virtual DbSet<TeamHasMatches> TeamHasMatches { get; set; }
        public virtual DbSet<TypeMatch> TypeMatches { get; set; }
        public virtual DbSet<University> Universities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // one to many university -> players
            modelBuilder.Entity<University>()
                .HasMany(u => u.Players);
            
            // teams -> players
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players);
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Players);
            
            // adding a primary key 
            modelBuilder.Entity<LeagueHasTeams>()
                .HasKey(k => k.Id);
            
            // one to many Team -> LeagueHasTeams
            modelBuilder.Entity<LeagueHasTeams>()
                .HasOne(lht => lht.Team)
                .WithMany(t => t.LeagueHasTeamsList);
            
            // one to many League -> LeagueHasTeams 
            modelBuilder.Entity<LeagueHasTeams>()
                .HasOne(lht => lht.League)
                .WithMany(l => l.LeagueHasTeamsList);
            base.OnModelCreating(modelBuilder);
            
            
            // adding a TeamMatches Id
            modelBuilder.Entity<TeamHasMatches>()
                .HasKey(thm => thm.Id);
            
            // one to many Team -> Thm
            modelBuilder.Entity<TeamHasMatches>()
                .HasOne(thm => thm.Team)
                .WithMany(t => t.TeamHasMatchesList);
            
            // one to many Match
            modelBuilder.Entity<TeamHasMatches>()
                .HasOne(thm => thm.Match)
                .WithMany(m => m.TeamHasMatchesList);
        }
    }
}