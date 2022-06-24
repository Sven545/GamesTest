using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesTest.DataAcsessLayer.Entities;

namespace GamesTest.DataAcsessLayer.EntityFramework
{
    public class DataBaseContext : Microsoft.EntityFrameworkCore.DbContext
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
            //   Database.EnsureDeleted();
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



            /*
            modelBuilder.Entity<Game>()
           .HasMany(p => p.Genres)
           .WithMany(p => p.Games)
           .UsingEntity<GameGenre>(
               j => j
                   .HasOne(pt => pt.Genre)
                   .WithMany(t => t.GameGenres)
                   .HasForeignKey(pt => pt.GenreId),
               j => j
                   .HasOne(pt => pt.Game)
                   .WithMany(p => p.GameGenres)
                   .HasForeignKey(pt => pt.GameId),
               j => j.HasKey(t => new { t.GameId, t.GenreId })
               );
            */
            /*
            modelBuilder.Entity<Game>()
                  .HasMany(p => p.Genres)
                  .WithMany(p => p.Games)
                  .UsingEntity<IntermediateTableGameGenre>(p => p
                  .HasOne(pt => pt.Genre)
                  .WithMany(t => t.IntermediateTableGamesGenres)
                  .HasForeignKey(p => p.GenreId), p => p
                     .HasOne(p => p.Game)
                     .WithMany(p => p.IntermediateTableGamesGenres)
                     .HasForeignKey(p => p.GameId), p => p
                        .HasKey(p => new { p.GameId, p.GenreId })
                );
                
               */
            modelBuilder.Entity<Game>().HasData(DefaultData.Games);
            modelBuilder.Entity<Genre>().HasData(DefaultData.Genres);
            modelBuilder.Entity<GameGenre>().HasData(DefaultData.GameGenres);
            modelBuilder.Entity<Developer>().HasData(DefaultData.Developers);
           
           
            /*
            modelBuilder
    .Entity<Game>()
    .HasMany(p => p.Genres)
    .WithMany(p => p.Games)
    .UsingEntity(j => j.HasData(new { GamesGameId = 1, GenresGenreId = 1 }));
            */
           // modelBuilder.Entity<Genre>().HasData(DefaultData.Genres);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //  optionsBuilder.UseSqlite("Data Source=helloapp.db");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GemesTestDataBase.db;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "DataBaseInMemory");

            }
        }
    }

}
