using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_Tracker.DisplayModels
{
    public class GameListItem
    {
        public int GameId { get; set; }

        public string Genre { get; set; }

        public double StarRating { get; set; }

        public string Title { get; set; }

        public string GameSystem { get; set; }

        public int GameSystemId { get; set; }
    }
}