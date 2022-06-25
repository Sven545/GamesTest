using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GamesTest.PresentationLayer.ViewModels;
using GamesTest.BusinessLogicLayer.Interfaces;
using AutoMapper;
using Ninject;
using GamesTest.BusinessLogicLayer.Services;
using System;
using GamesTest.BusinessLogicLayer.DataTransferObjects;

namespace GamesTest.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/genres")]
    public class GenreController : Controller
    {
        private ICrudGenreService crudService;
        private Mapper mapper;
        public GenreController()
        {

            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICrudGenreService>().To<CrudGenreService>();
            crudService = ninjectKernel.Get<ICrudGenreService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GameDTO, GameViewModel>().ForMember(p => p.Genres, opt => opt.MapFrom(p => p.GameGenres));
                cfg.CreateMap<GenreDTO, GenreViewModel>();
                cfg.CreateMap<DeveloperDTO, DeveloperViewModel>();
                cfg.CreateMap<GameGenreDTO, GenreViewModel>()
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Genre.Name))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Genre.Id));
            });
            mapper = new Mapper(config);

        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            try
            {
                var allGenresDTO = crudService.GetAll();
                var allGenresViewModel = mapper.Map<IEnumerable<GenreDTO>, IEnumerable<GenreViewModel>>(allGenresDTO);
                return Ok(allGenresViewModel);
            }
            catch (Exception)
            {
                return Problem();
            }

        }
    }
}
