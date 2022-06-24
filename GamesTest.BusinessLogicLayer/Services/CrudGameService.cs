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
        IRepository<Game> gameRepository;
        private Mapper mapper;
        public CrudGameService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IRepository<Game>>().To<GameRepository<Game>>();
            gameRepository = ninjectKernel.Get<IRepository<Game>>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>().ReverseMap();
                cfg.CreateMap<Developer, DeveloperDTO>().ReverseMap();
                cfg.CreateMap<GameGenre, GameGenreDTO>().ReverseMap();
                cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
            });
            mapper = new Mapper(config);
        }

        public void Add(GameDTO newGame)
        {
            
                gameRepository.Add(mapper.Map<GameDTO, Game>(newGame));
            
            
           
        }

        public IEnumerable<GameDTO> GetAll()
        {
            return mapper.Map<IEnumerable<Game>,IEnumerable<GameDTO>>(gameRepository.GetAll());
        }

        public GameDTO GetOne(int id)
        {
            var test = gameRepository.GetOne(id);
            return mapper.Map<Game,GameDTO>(gameRepository.GetOne(id));
        }

        public void Remove(int id)
        {
           gameRepository.Remove(id);   
        }

        public void Update(GameDTO newGame)
        {
            throw new NotImplementedException();
        }
    }
}
