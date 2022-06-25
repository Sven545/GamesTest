using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GamesTest.PresentationLayer.ViewModels;
using GamesTest.BusinessLogicLayer.Interfaces;
using AutoMapper;
using Ninject;
using GamesTest.BusinessLogicLayer.Services;
using System;
using GamesTest.BusinessLogicLayer.DataTransferObjects;
using System.Linq;

namespace GamesTest.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/developers")]
    public class DeveloperController:Controller
    {
        private ICrudDeveloperService crudService;
        private Mapper mapper;
        public DeveloperController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICrudDeveloperService>().To<CrudDeveloperService>();
            crudService = ninjectKernel.Get<ICrudDeveloperService>();

            var config = new MapperConfiguration(cfg =>
            {
               // cfg.CreateMap<GameDTO, GameViewModel>().ForMember(p => p.Genres, opt => opt.MapFrom(p => p.GameGenres));
                //cfg.CreateMap<GenreDTO, GenreViewModel>();
                cfg.CreateMap<DeveloperDTO, DeveloperViewModel>();
               // cfg.CreateMap<GameGenreDTO, GenreViewModel>().ForMember(p => p.Name, opt => opt.MapFrom(p => p.Genre.Name));
            });
            mapper = new Mapper(config);
        }
        [HttpGet]
        public IActionResult GetAllDevelopers()
        {
            try
            {
                var allDevelopersDTO = crudService.GetAll();
                var allDevelopersViewModel = mapper.Map<IEnumerable<DeveloperDTO>, IEnumerable<DeveloperViewModel>>(allDevelopersDTO);
                return Ok(allDevelopersViewModel);
            }
            catch (Exception)
            {
                return Problem();
            }


        }
    }
}
