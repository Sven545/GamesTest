using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesTest.DataAcsessLayer.Interfaces;
using GamesTest.DataAcsessLayer.Entities;
using Ninject;
using GamesTest.DataAcsessLayer.Repositories;
using GamesTest.BusinessLogicLayer.Interfaces;
using GamesTest.BusinessLogicLayer.DataTransferObjects;
using AutoMapper;

namespace GamesTest.BusinessLogicLayer.Services
{
    public class CrudGameService : ICrudGameService
    {
        private IGameRepository gameRepository;
        private IDeveloperRepository developerRepository;
        private IGenreRepository genreRepository;
        private Mapper mapper;
        public CrudGameService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IGameRepository>().To<GameRepository>();
            ninjectKernel.Bind<IDeveloperRepository>().To<DeveloperRepository>();
            ninjectKernel.Bind<IGenreRepository>().To<GenreRepository>();
            gameRepository = ninjectKernel.Get<IGameRepository>();
            developerRepository = ninjectKernel.Get<IDeveloperRepository>();
            genreRepository = ninjectKernel.Get<IGenreRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>().ReverseMap();
                cfg.CreateMap<Developer, DeveloperDTO>().ReverseMap();
                cfg.CreateMap<GameGenre, GameGenreDTO>().ReverseMap();
                cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
            });
            mapper = new Mapper(config);
        }
       
        public void Add(GameDTO newGameDTO)
        {
            Game gameFromDb;
            Game newGame = mapper.Map<GameDTO, Game>(newGameDTO);
            if (DbContainsGame(newGame.Id, out gameFromDb) == false)
            {
                if (GameModelIsValid(newGame))
                {
                    gameRepository.Add(newGame);
                }
            }
            else
            {
                throw new ArgumentException($"Game with id:{newGame.Id} added earlier");
            }

        }

        public IEnumerable<GameDTO> GetAll()
        {
           // var test= mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(gameRepository.GetAll());
            return mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(gameRepository.GetAll());
        }

        public GameDTO GetOne(int id)
        {
            Game gameFromDb;
            //var gameFromDb = gameRepository.GetOne(id);
            if (DbContainsGame(id, out gameFromDb))
            {
                return mapper.Map<Game, GameDTO>(gameFromDb);
            }
            else throw new ArgumentException($"Game with id:{id} not found");

        }

        public void Remove(int id)
        {
            Game gameFromDb;
            if (DbContainsGame(id, out gameFromDb) == true)
            {
                gameRepository.Remove(gameFromDb);
            }
            else throw new ArgumentException($"Game with id:{id} not found");

        }

        public void Update(GameDTO newGameDTO)
        {
            Game gameFromDb;
            Game newGame = mapper.Map<GameDTO, Game>(newGameDTO);
            // var newGame = newEntity as Game;
            if (DbContainsGame(newGame.Id, out gameFromDb) == true)
            {
                if (GameModelIsValid(newGame))
                {
                    gameRepository.Remove(gameFromDb);
                    gameRepository.Add(newGame);
                }
            }
            else
            {
                throw new ArgumentException($"Game with id:{newGame.Id} not found");
            }

            // gameRepository.Update(mapper.Map<GameDTO, Game>(newGame));
        }

        private List<int> ConvertGameGenresListToGenreIdsList(List<GameGenre> gameGenres)
        {
            var genreIds = from gameGenre in gameGenres
                           select gameGenre.GenreId;
            return genreIds.ToList();
        }
        private bool DeveloperValidation(int developerId)
        {
            var developerFromDb = developerRepository.GetOne(developerId);
            if (developerFromDb == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool GenresValidation(IEnumerable<int> genreIds)
        {
            var genreIdsFromRequestNotContainedInDb = genreIds.Except(from genre in genreRepository.GetAll()
                                                                      select genre.Id).ToList();
            if (genreIdsFromRequestNotContainedInDb.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool GameModelIsValid(Game game)
        {
            if (DeveloperValidation(game.DeveloperId) == false)
            {
                throw new ArgumentException($"No developer with id:{game.DeveloperId}");
            }
            if (GenresValidation(ConvertGameGenresListToGenreIdsList(game.GameGenres)) == false)
            {
                throw new ArgumentException($"Bad genres list");
            }
            return true;
        }
        private bool DbContainsGame(int gameId, out Game game)
        {
            var gameFromDb = gameRepository.GetOne(gameId);
            game = gameFromDb;
            if (gameFromDb != null)
            {
                return true;
            }
            else return false;
        }
    }
}
