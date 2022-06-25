using System.Collections.Generic;
using AutoMapper;
using GamesTest.BusinessLogicLayer.DataTransferObjects;
using GamesTest.BusinessLogicLayer.Interfaces;
using GamesTest.DataAcsessLayer.Entities;
using GamesTest.DataAcsessLayer.Interfaces;
using GamesTest.DataAcsessLayer.Repositories;
using Ninject;

namespace GamesTest.BusinessLogicLayer.Services
{
    public class CrudDeveloperService : ICrudDeveloperService
    {
        private IDeveloperRepository developerRepository;
        private Mapper mapper;
        public CrudDeveloperService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IDeveloperRepository>().To<DeveloperRepository>();

            developerRepository = ninjectKernel.Get<IDeveloperRepository>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Game, GameDTO>().ReverseMap();
                cfg.CreateMap<Developer, DeveloperDTO>().ReverseMap();
                cfg.CreateMap<GameGenre, GameGenreDTO>().ReverseMap();
                cfg.CreateMap<Genre, GenreDTO>().ReverseMap();
            });
            mapper = new Mapper(config);
        }
        public IEnumerable<DeveloperDTO> GetAll()
        {
            var allDevelopers = developerRepository.GetAll();
            var allDevelopersDTO = mapper.Map<IEnumerable<Developer>, IEnumerable<DeveloperDTO>>(allDevelopers);
            return allDevelopersDTO;
        }
    }
}
