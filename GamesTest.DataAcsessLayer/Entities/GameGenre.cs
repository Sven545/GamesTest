﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTest.DataAcsessLayer.Entities
{
    public class GameGenre
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
