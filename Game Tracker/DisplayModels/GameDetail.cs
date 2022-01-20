using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Game_Tracker.Models.Game;

namespace Game_Tracker.DisplayModels
{
    public class GameDetail
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public AgeRating ESRBRating { get; set; }
        public double StarRating { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
        public int GameSystemId { get; set; }
        public string GameSystemName { get; set; }
    }
}