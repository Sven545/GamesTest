using GamesTest.DataAcsessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.EntityFramework
{
    public static class DefaultData
    {
        private static Genre fps = new Genre() { Id = 1, Name = "FPS" };
        private static Genre action = new Genre() { Id = 2, Name = "Экшен" };
        private static Genre adventure = new Genre() { Id = 3, Name = "Приключение" };
        private static Genre puzzle = new Genre() { Id = 4, Name = "Паззл" };
        private static Genre arcade = new Genre() { Id = 5, Name = "Аркада" };
        private static Genre simulator = new Genre() { Id = 6, Name = "Симулятор" };
        private static Genre rolePlaying = new Genre() { Id = 7, Name = "Ролевая игра" };
        private static Genre strategy = new Genre() { Id = 8, Name = "Стратегия" };
        private static Genre manager = new Genre() { Id = 9, Name = "Менеджер" };
        private static Genre mmo = new Genre() { Id = 10, Name = "ММО" };
        private static Genre race = new Genre() { Id = 11, Name = "Гонки" };
        private static Genre stealth = new Genre() { Id = 12, Name = "Стелс" };
        private static Genre sport = new Genre() { Id = 13, Name = "Cпорт" };

        private static Developer valve = new Developer() { Id = 1, Name = "Valve" };
        private static Developer remedyEntertainment = new Developer() { Id = 2, Name = "Remedy Entertainment" };
        private static Developer microsoftStudios = new Developer() { Id = 3, Name = "Microsoft Studios" };
        private static Developer rockstarGames = new Developer() { Id = 4, Name = "Rockstar Games" };
        private static Developer mojangStudios = new Developer() { Id = 5, Name = "Mojang Studios" };
        private static Developer wargaming = new Developer() { Id = 6, Name = "Wargaming" };
        private static Developer cdProjekt = new Developer() { Id = 7, Name = "CD Projekt" };
        private static Developer konami = new Developer() { Id = 8, Name = "Konami" };

       // private static Game halfLife2 = new Game() { Id = 1, Name = "Half-Life 2", DeveloperId = 1, GenresId = new List<int>() { 1, 2 } };
       // private static Game maxPayne = new Game() { Id = 2, Name = "Max Payne", DeveloperId = 2, GenresId = new List<int>() { 1, 2 } };

        private static Game halfLife2 = new Game() { Id = 1, Name = "Half-Life 2", DeveloperId = 1 };
         private static Game maxPayne = new Game() { Id = 2, Name = "Max Payne", DeveloperId = 2 };
        
        private static Game portal = new Game() { Id = 3, Name = "Portal", DeveloperId = 1};
        private static Game mfs = new Game() { Id = 4, Name = "Microsoft Flight Simulator", DeveloperId = 3 };
        private static Game rdr2 = new Game() { Id = 5, Name = "Red Dead Redemption 2", DeveloperId = 4};
        private static Game minecraft = new Game() { Id = 6, Name = "Minecraft", DeveloperId = 5 };
        private static Game wot = new Game() { Id = 7, Name = "World of Tanks", DeveloperId = 6 };
        private static Game forzaHorizon4 = new Game() { Id = 8, Name = "Forza Horizon 4", DeveloperId = 3 };
        private static Game cyberpunk2077 = new Game() { Id = 9, Name = "Cyberpunk 2077", DeveloperId = 7};
        private static Game metalGearSolid = new Game() { Id = 10, Name = "Metal Gear Solid", DeveloperId = 8};
        

        private static GameGenre game1Genre1 = new GameGenre() { GameId = 1, GenreId = 1 };
        private static GameGenre game1Genre2 = new GameGenre() { GameId = 1, GenreId = 2 };

        private static GameGenre game2Genre1 = new GameGenre() { GameId = 2, GenreId = 1 };
        private static GameGenre game2Genre2 = new GameGenre() { GameId = 2, GenreId = 2 };

        private static GameGenre game3Genre1 = new GameGenre() { GameId = 3, GenreId = 3 };
        private static GameGenre game3Genre2 = new GameGenre() { GameId = 3, GenreId = 2 };
        private static GameGenre game3Genre3 = new GameGenre() { GameId = 3, GenreId = 4 };
        private static GameGenre game3Genre4 = new GameGenre() { GameId = 3, GenreId = 5 };

        private static GameGenre game4Genre1 = new GameGenre() { GameId = 4, GenreId = 6 };

        private static GameGenre game5Genre1 = new GameGenre() { GameId = 5, GenreId = 3 };
        private static GameGenre game5Genre2 = new GameGenre() { GameId = 5, GenreId = 7 };
        private static GameGenre game5Genre3 = new GameGenre() { GameId = 5, GenreId = 2 };

        private static GameGenre game6Genre1 = new GameGenre() { GameId = 6, GenreId = 3 };
        private static GameGenre game6Genre2 = new GameGenre() { GameId = 6, GenreId = 8 };
        private static GameGenre game6Genre3 = new GameGenre() { GameId = 6, GenreId = 6 };
        private static GameGenre game6Genre4 = new GameGenre() { GameId = 6, GenreId = 4 };
        private static GameGenre game6Genre5 = new GameGenre() { GameId = 6, GenreId = 9 };

        private static GameGenre game7Genre1 = new GameGenre() { GameId = 7, GenreId = 1 };
        private static GameGenre game7Genre2 = new GameGenre() { GameId = 7, GenreId = 2 };
        private static GameGenre game7Genre3 = new GameGenre() { GameId = 7, GenreId = 6 };
        private static GameGenre game7Genre4 = new GameGenre() { GameId = 7, GenreId = 10 };

        private static GameGenre game8Genre1 = new GameGenre() { GameId = 8, GenreId = 5 };
        private static GameGenre game8Genre2 = new GameGenre() { GameId = 8, GenreId = 10 };
        private static GameGenre game8Genre3 = new GameGenre() { GameId = 8, GenreId = 11 };
        private static GameGenre game8Genre4 = new GameGenre() { GameId = 8, GenreId = 13 };

        private static GameGenre game9Genre1 = new GameGenre() { GameId = 9, GenreId = 2 };
        private static GameGenre game9Genre2 = new GameGenre() { GameId = 9, GenreId = 7 };

        private static GameGenre game10Genre1 = new GameGenre() { GameId = 10, GenreId = 2 };
        private static GameGenre game10Genre2 = new GameGenre() { GameId = 10, GenreId = 3 };
        private static GameGenre game10Genre3 = new GameGenre() { GameId = 10, GenreId = 12 };

        /*
        private static Developer developer = new Developer() { Id = 1, Name = "testDev" };
        private static Game game1 = new Game() { Id = 1, Name = "game1", DeveloperId = 1 };
        private static Game game2 = new Game() { Id = 2, Name = "game2", DeveloperId = 1 };
        */

        public static readonly List<Developer> Developers = new List<Developer>
    {
        valve,
        remedyEntertainment,
        microsoftStudios,
        rockstarGames,
        mojangStudios,
        wargaming,
        cdProjekt,
        konami

    };
        public static readonly List<Game> Games = new List<Game>
    {
     halfLife2,
     maxPayne,
     portal,
     mfs,
     rdr2,
     minecraft,
     wot,
     forzaHorizon4,
     cyberpunk2077,
     metalGearSolid

    };

        public static readonly List<Genre> Genres = new List<Genre>
    {
     fps,
     action,
     adventure,
     puzzle,
     arcade,
     simulator,
     rolePlaying,
     strategy,
     manager,
     mmo,
     race,
     stealth,
     sport

    };

        public static readonly List<GameGenre> GameGenres = new List<GameGenre>
        {
            game1Genre1,
            game1Genre2,
            game2Genre1,
            game2Genre2,
            game3Genre1,
            game3Genre2,
            game3Genre3,
            game3Genre4,
            game4Genre1,
            game5Genre1,
            game5Genre2,
            game5Genre3,
            game6Genre1,
            game6Genre2,
            game6Genre3,
            game6Genre4,
            game6Genre5,
            game7Genre1,
            game7Genre2,
            game7Genre3,
            game7Genre4,
            game8Genre1,
            game8Genre2,
            game8Genre3,
            game8Genre4,
            game9Genre1,
            game9Genre2,
            game10Genre1,
            game10Genre2,
            game10Genre3
           
        };
    }


}

