using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using static Game_Tracker.Models.Game;

namespace Game_Tracker.DisplayModels
{
    public class GameEdit
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public AgeRating ESRBRating { get; set; }
        public double StarRating { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [ForeignKey(nameof(GameSystem))]
        public int GameSystemId { get; set; }
        public virtual GameSystem GameSystem { get; set; }
    }
}