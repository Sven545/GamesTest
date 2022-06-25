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
                cfg.CreateMap<GameGenreDTO, GenreViewModel>()
                .ForMember(p => p.Name, opt => opt.MapFrom(p => p.Genre.Name))
                .ForMember(p => p.Id, opt => opt.MapFrom(p => p.Genre.Id));
                
            });
            mapper = new Mapper(config);
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {                
                var allGames = mapper.Map<IEnumerable<GameDTO>, IEnumerable<GameViewModel>>(crudService.GetAll()).ToList();
                if (allGames.Count > 0)
                {
                    return Ok(allGames);
                }
                else return NoContent();
            }
            catch (Exception)
            {
                return Problem();
            }

        }
        
        [HttpGet("{id}")]
        public IActionResult GetOneGame(int id)
        {
            try
            {
                return Ok(mapper.Map<GameDTO, GameViewModel>(crudService.GetOne(id)));
            }
            catch(ArgumentException)
            {
                return NoContent();
            }
            catch(Exception)
            {
                return Problem();
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
            catch(Exception)
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
                try
                {
                    crudService.Update(newGame);
                    return Ok($"Game with id:{newGame.Id} updated");
                }
                catch (ArgumentException ex)
                {
                    return BadRequest(ex.Message);
                }
                catch (Exception)
                {
                    return Problem("Is something wrong");
                }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGame(int id)
        {
            try
            {
               crudService.Remove(id);
                return Ok($"Game with id:{id} deleted");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return Problem("Is something wrong");
            }

        }
       
    }
}
