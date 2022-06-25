using AutoMapper;
using GamesTest.BusinessLogicLayer.BusinessModels;
using GamesTest.BusinessLogicLayer.DataTransferObjects;
using GamesTest.BusinessLogicLayer.Interfaces;
using GamesTest.PresentationLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GamesTest.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/games/filter")]
    public class GameFilterController : Controller
    {
        private IGameFilterService gameFilterService;
        private Mapper mapper;
        public GameFilterController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IGameFilterService>().To<GameFilter>();
            gameFilterService = ninjectKernel.Get<IGameFilterService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GameDTO, GameViewModel>().ForMember(p => p.Genres, opt => opt.MapFrom(p => p.GameGenres));
                cfg.CreateMap<DeveloperDTO, DeveloperViewModel>();
                cfg.CreateMap<GameGenreDTO, GenreViewModel>()
               .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Genre.Name))
               .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Genre.Id));
            });
            mapper = new Mapper(config);
        }

        [HttpGet("{genreId}")]
        public IActionResult GetAllGamesOfGenre(int genreId)
        {
            try
            {
                var allGamesOfGenreDTO = gameFilterService.GetAllGamesOfGenre(genreId).ToList();
                var allGamesOfGenreViewModel = mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameViewModel>>(allGamesOfGenreDTO).ToList();
                if (allGamesOfGenreViewModel.Count > 0)
                {
                    return Ok(allGamesOfGenreViewModel);
                }
                else return NoContent();
            }
            catch(Exception)
            {
                return Problem();
            }
            
        }
    }
}
