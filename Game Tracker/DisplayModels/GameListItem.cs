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

        public Genre Genre { get; set; }

        public double StarRating { get; set; }

        public string Title { get; set; }
    }
}