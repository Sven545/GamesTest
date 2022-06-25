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
    public class CrudGenreService : ICrudGenreService
    {
        private IGenreRepository genreRepository;
        private Mapper mapper;

        public CrudGenreService()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IGenreRepository>().To<GenreRepository>();

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
        public IEnumerable<GenreDTO> GetAll()
        {
            var allGenres=genreRepository.GetAll();
            var allGenresDTO = mapper.Map<IEnumerable<Genre>, IEnumerable<GenreDTO>>(allGenres);
            return allGenresDTO;
        }
    }
}
