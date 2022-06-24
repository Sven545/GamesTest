using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GamesTest.PresentationLayer.ViewModels;
using GamesTest.BusinessLogicLayer.Interfaces;
using AutoMapper;
//using GamesTest.DataAcsessLayer.Entities;
using Ninject;
using GamesTest.BusinessLogicLayer.Services;
using System;
using GamesTest.BusinessLogicLayer.DataTransferObjects;

namespace GamesTest.PresentationLayer.Controllers
{
    [ApiController]
    [Route("api/games")]
    public class GameController : Controller
    {
        private ICrudGameService crudService;
        private Mapper mapper;

        public GameController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICrudGameService>().To<CrudGameService>();
            crudService = ninjectKernel.Get<ICrudGameService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GameDTO, GameViewModel>().ForMember(p=>p.Genres,opt=>opt.MapFrom(p=>p.GameGenres));
                cfg.CreateMap<DeveloperDTO, DeveloperViewModel>();
                cfg.CreateMap<GameGenreDTO, GenreViewModel>().ForMember(p => p.Name, opt => opt.MapFrom(p => p.Genre.Name));
            });
            mapper = new Mapper(config);
        }

        [HttpGet]
        public IEnumerable<GameViewModel> Get()
        {
            var test1 = crudService.GetAll();
           
            var test2= mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameViewModel>>(test1);
            return mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameViewModel>>(test1);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetOneGame(int id)
        {
            try
            {
                return Ok(mapper.Map<GameDTO, GameViewModel>(crudService.GetOne(id)));
            }
            catch(NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
          
        }

        [HttpPost("{gameId},{gameName},{developerId}")]
        public IActionResult AddGame(int gameId, string gameName, int developerId,IEnumerable<int> genreIds)
        {
            
            GameDTO newGame=new GameDTO() { Id=gameId,Name=gameName,DeveloperId=developerId};
            foreach(var genreId in genreIds)
            {
                newGame.GameGenres.Add(new GameGenreDTO() { GameId=gameId, GenreId=genreId });
            }
            try
            {
                crudService.Add(newGame);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return Problem("Is something wrong");
            }
           
            
            
        }
        [HttpPut("{gameId},{gameName},{developerId}")]
        public IActionResult ChangeGame(int gameId, string gameName, int developerId, IEnumerable<int> genreIds)
        {

            GameDTO newGame = new GameDTO() { Id = gameId, Name = gameName, DeveloperId = developerId };
            foreach (var genreId in genreIds)
            {
                newGame.GameGenres.Add(new GameGenreDTO() { GameId = gameId, GenreId = genreId });
            }
            crudService.Add(newGame);

            return Ok();
        }

    }
}
