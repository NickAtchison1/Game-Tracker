using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Game_Tracker.Models
{
    public class GameSystem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}