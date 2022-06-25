using Microsoft.EntityFrameworkCore;
using GamesTest.DataAcsessLayer.Entities;

namespace GamesTest.DataAcsessLayer.EntityFramework
{
    public class DataBaseContext :DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
           : base(options)
        {
        }

        public DataBaseContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Game>()
           .HasOne(c => c.Developer)
           .WithMany(e => e.Games)
           .HasForeignKey(p => p.DeveloperId)
           .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<GameGenre>()
           .HasKey(t => new { t.GameId, t.GenreId });

            modelBuilder.Entity<GameGenre>()
                .HasOne(pt => pt.Genre)
                .WithMany(t => t.GameGenres)
                .HasForeignKey(pt => pt.GenreId);

            modelBuilder.Entity<GameGenre>()
                .HasOne(pt => pt.Game)
                .WithMany(p => p.GameGenres)
                .HasForeignKey(pt => pt.GameId);

            modelBuilder.Entity<Game>().HasData(DefaultData.Games);
            modelBuilder.Entity<Genre>().HasData(DefaultData.Genres);
            modelBuilder.Entity<GameGenre>().HasData(DefaultData.GameGenres);
            modelBuilder.Entity<Developer>().HasData(DefaultData.Developers);
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "DataBaseInMemory");

            }
        }
    }

}
