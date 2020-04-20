using ImperiumSite.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Models
{
    public class LeaderboardBaseViewModel
    {
        [Key]
        public int LEADERBOARD_ID { get; set; }

        public int PLAYER_ID { get; set; }

        public int LEADERBOARD_LEVEL { get; set; }

        public int LEADERBOARD_WINS { get; set; }

        public int LEADERBOARD_LOSSES { get; set; }

        public int LEADERBOARD_GAMESPLAYED { get; set; }

        public int LEADERBOARD_WINRATE { get; set; }

        public PlayersBaseViewModel Player { get; set; }
    }
}
