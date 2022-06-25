using System.Collections.Generic;
using System.Linq;
using GamesTest.BusinessLogicLayer.DataTransferObjects;
using GamesTest.BusinessLogicLayer.Interfaces;
using GamesTest.DataAcsessLayer.Entities;
using GamesTest.DataAcsessLayer.Interfaces;
using GamesTest.DataAcsessLayer.Repositories;
using Ninject;
using AutoMapper;

namespace GamesTest.BusinessLogicLayer.BusinessModels
{
    public class GameFilter : IGameFilterService
    {
        private IGameRepository gameRepository;
        private Mapper mapper;

        public GameFilter()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IGameRepository>().To<GameRepository>();
            gameRepository = ninjectKernel.Get<IGameRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>();
                cfg.CreateMap<Developer, DeveloperDTO>();
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<GameGenre, GameGenreDTO>();

            });
            mapper = new Mapper(config);
        }

        public IEnumerable<GameDTO> GetAllGamesOfGenre(int genreId)
        {
            var allGamesOfGenre = gameRepository.GetAllGamesOfGenre(genreId).ToList();
            return mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(allGamesOfGenre);

        }

    }
}
