using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesTest.DataAcsessLayer.Entities;

namespace GamesTest.DataAcsessLayer.EntityFramework
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
       
       public DbSet<Game> Games { get; set; }
       public DbSet<Developer> Developers{ get; set; }
       public DbSet<Genre> Genres{ get; set; }

    public DbContext(DbContextOptions<DbContext> options)
       : base(options)
        {

           // DataInitialization.Initialize(this);



        }

        public DbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            //DataInitialization.Initialize(this);
            /*
            Developer valve = new Developer() { Name = "Valve" };
            Game halfLife2 = new Game() { Name = "Half-Life 2", Developer = valve };
            this.Developers.Add(valve);  // добавление компаний
            this.Games.Add(halfLife2);     // добавление пользователей
           this.SaveChanges();
            */
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Game>()
                .HasKey(p => p.Id);

         
            
            Developer valve = new Developer() { Name = "Valve" };
            Genre fps = new Genre() {  Name = "FPS" };
            Genre action = new Genre() {  Name = "Экшен" };
            Game halfLife2 = new Game() { Name = "Half-Life 2",Developer = valve/*,Genres = new List<Genre>() { fps, action }*/};
            /*
            modelBuilder.Entity<Game>().OwnsOne(e => e.Genres).HasData(
           new Game[]
           {
               halfLife2

           });
             */
            
            modelBuilder.Entity<Game>().HasData(
           new Game[]
           {
               halfLife2

           });
            
           // base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlite("Data Source=helloapp.db");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GemesTestDataBase.db;Trusted_Connection=True;");
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=relationsdb;Trusted_Connection=True;");
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseInMemoryDatabase(databaseName: "DataBaseInMemory");
               
            }
        }
    }
}
