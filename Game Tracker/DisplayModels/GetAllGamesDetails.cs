using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_Tracker.DisplayModels
{
    public class GetAllGamesDetails
    {
        public string Title { get; set; }
        public string GameSystemName { get; set; }
        public string Rating { get; set; }

        public double StarRating { get; set; }
    }
       
}