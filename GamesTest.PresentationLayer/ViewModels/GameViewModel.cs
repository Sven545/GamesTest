using System.Collections.Generic;

namespace GamesTest.PresentationLayer.ViewModels
{
    
    public class GameViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DeveloperViewModel Developer { get; set; }
        public List<GenreViewModel> Genres { get; set; }
    }
}
