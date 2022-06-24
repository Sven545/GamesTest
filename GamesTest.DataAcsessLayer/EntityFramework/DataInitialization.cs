using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesTest.DataAcsessLayer.Entities;

namespace GamesTest.DataAcsessLayer.EntityFramework
{
    internal class DataInitialization
    {
        private static bool _isInitialized = false;

        public static void Initialize(DataBaseContext context)
        {
            if (_isInitialized == false)
            {/*
                Genre fps = new Genre() { GenreId = 1, Name = "FPS" };
                Genre action = new Genre() { GenreId = 2, Name = "Экшен" };
                Genre adventure = new Genre() { GenreId = 3, Name = "Приключение" };
                Genre puzzle = new Genre() { GenreId = 4, Name = "Паззл" };
                Genre arcade = new Genre() { GenreId = 5, Name = "Аркада" };
                Genre simulator = new Genre() { GenreId = 6, Name = "Симулятор" };
                Genre rolePlaying = new Genre() { GenreId = 7, Name = "Ролевая игра" };
                Genre strategy = new Genre() { GenreId = 8, Name = "Стратегия" };
                Genre manager = new Genre() { GenreId = 9, Name = "Менеджер" };
                Genre mmo = new Genre() { GenreId = 10, Name = "ММО" };
                Genre race = new Genre() { GenreId = 11, Name = "Гонки" };
                Genre stealth = new Genre() { GenreId = 12, Name = "Стелс" };
                Genre sport = new Genre() { GenreId = 13, Name = "Cпорт" };
                
                List<Genre> genres = new List<Genre>();
                genres.Add(fps);
                genres.Add(action);
                genres.Add(adventure);
                genres.Add(puzzle);
                genres.Add(arcade);
                genres.Add(simulator);
                genres.Add(rolePlaying);
                genres.Add(strategy);
                genres.Add(manager);
                genres.Add(mmo);
                genres.Add(race);
                genres.Add(stealth);
                genres.Add(sport);
              */
               // context.SaveChanges();

                Developer valve = new Developer() {  Name = "Valve" };
                Developer remedyEntertainment = new Developer() { Id = 2, Name = "Remedy Entertainment" };
                Developer microsoftStudios = new Developer() { Id = 3, Name = "Microsoft Studios" };
                Developer rockstarGames = new Developer() { Id = 4, Name = "Rockstar Games" };
                Developer mojangStudios = new Developer() { Id = 5, Name = "Mojang Studios" };
                Developer wargaming = new Developer() { Id = 6, Name = "Wargaming" };
                Developer cdProjekt = new Developer() { Id = 7, Name = "CD Projekt" };
                Developer konami = new Developer() { Id = 8, Name = "Konami" };

                List<Developer> developers = new List<Developer>();
               // developers.Add(valve);
                developers.Add(remedyEntertainment);
                developers.Add(microsoftStudios);
                developers.Add(rockstarGames);
                developers.Add(mojangStudios);
                developers.Add(wargaming);
                developers.Add(cdProjekt);
                developers.Add(konami);
               
               // context.SaveChanges();
               
               Game halfLife2 = new Game() {  Name = "Half-Life 2", Developer = valve/*, Genres = new List<Genre>() { fps, action }*/ };
                /*
                Game maxPayne = new Game() { Id = 2, Name = "Max Payne", Developer = remedyEntertainment, Genres = new List<Genre>() { fps, action } };
                Game portal = new Game() { Id = 3, Name = "Portal", Developer = valve, Genres = new List<Genre>() { adventure, action, puzzle, arcade } };
                Game mfs = new Game() { Id = 4, Name = "Microsoft Flight Simulator", Developer = microsoftStudios, Genres = new List<Genre>() { simulator } };
                Game rdr2 = new Game() { Id = 5, Name = "Red Dead Redemption 2", Developer = rockstarGames, Genres = new List<Genre>() { adventure, rolePlaying, action } };
                Game minecraft = new Game() { Id = 6, Name = "Minecraft", Developer = mojangStudios, Genres = new List<Genre>() { adventure, strategy, simulator, puzzle, manager } };
                Game wot = new Game() { Id = 7, Name = "World of Tanks", Developer = wargaming, Genres = new List<Genre>() { fps, action, mmo, simulator } };
                Game forzaHorizon4 = new Game() { Id = 8, Name = "Forza Horizon 4", Developer = microsoftStudios, Genres = new List<Genre>() { sport, mmo, race, arcade } };
                Game cyberpunk2077 = new Game() { Id = 9, Name = "Cyberpunk 2077", Developer = cdProjekt, Genres = new List<Genre>() { rolePlaying, action } };
                Game metalGearSolid = new Game() { Id = 10, Name = "Metal Gear Solid", Developer = konami, Genres = new List<Genre>() { adventure, action, stealth } };
                */
                /*
                valve.Games = new List<Game>() { halfLife2, portal };
                remedyEntertainment.Games = new List<Game>() { maxPayne };
                microsoftStudios.Games = new List<Game>() { mfs, forzaHorizon4 };
                rockstarGames.Games = new List<Game>() { rdr2 };
                mojangStudios.Games = new List<Game>() { minecraft };
                wargaming.Games = new List<Game>() { wot };
                cdProjekt.Games = new List<Game>() { cyberpunk2077 };
                konami.Games = new List<Game>() { metalGearSolid };


                */
                List<Game> games = new List<Game>();
               // games.Add(halfLife2);
                /*
                games.Add(maxPayne);
                games.Add(portal);
                games.Add(mfs);
                games.Add(rdr2);
                games.Add(minecraft);
                games.Add(wot);
                games.Add(forzaHorizon4);
                games.Add(cyberpunk2077);
                games.Add(metalGearSolid);
                */
                /*
                context.Developers.AddRange(developers);
                //context.Genres.AddRange(genres);
                context.Games.AddRange(games);
                //context.Genres.AddRange(genres);
                context.SaveChanges();
                */

                //Developer valve = new Developer() { Name = "Valve" };
               // Game halfLife2 = new Game() { Name = "Half-Life 2", Developer = valve };
                context.Developers.Add(valve);  // добавление компаний
                context.Games.Add(halfLife2);     // добавление пользователей
                context.SaveChanges();
                _isInitialized = true;
            }

        }
    }
}
