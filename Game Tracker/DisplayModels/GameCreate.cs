using Game_Tracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Game_Tracker.Models.Game;

namespace Game_Tracker.DisplayModels
{
    public class GameCreate
    {
        public int GameId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ReleaseDate { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        public AgeRating ESRBRating { get; set; }        
        public double StarRating { get; set; }
        public int GenreId { get; set; }
        public int GameSystemId { get; set; }
    }
}