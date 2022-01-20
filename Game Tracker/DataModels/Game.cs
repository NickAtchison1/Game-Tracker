using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Game_Tracker.Models
{
    public class Game
    {
        public enum AgeRating
        {
            E = 1,
            E10,
            T,
            M
        }
        [Key]
        public int GameId { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Publisher { get; set; }
        public AgeRating ESRBRating { get; set; }
        [Range(1,5)]
        public double StarRating { get; set; }

        [ForeignKey(nameof(Genre))]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }

        [ForeignKey(nameof(GameSystem))]
        public int GameSystemId { get; set; }
        public virtual GameSystem GameSystem { get; set; }
    }
}