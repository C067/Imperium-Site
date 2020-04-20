using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace ImperiumSite.Models
{
    public class PlayersBaseViewModel
    {
        public PlayersBaseViewModel()
        {
            this.PLAYER_DATEREGISTERED = DateTime.Now;
        }

        public PlayersBaseViewModel(PlayerAddFormViewModel newPlayer)
        {
            this.PLAYER_USERNAME = newPlayer.Username;
            this.PLAYER_EMAIL = newPlayer.Email;
            this.PLAYER_PASSWORD = Crypto.HashPassword(newPlayer.Password);
            this.PLAYER_PASSWORDCOUNT = 0;
            this.PLAYER_INGAME = false;
            this.PLAYER_LOGGEDON = false;
            this.PLAYER_DATEREGISTERED = DateTime.Now;
        }

        [Key]
        public int PLAYER_ID { get; set; }

        public string PLAYER_USERNAME { get; set; }

        public string PhotoUrl
        {
            get
            {
                return $"/photo/{PLAYER_ID}";
            }
        }

        public string PLAYER_PASSWORD { get; set; }

        public int PLAYER_PASSWORDCOUNT { get; set; }

        public string PLAYER_EMAIL { get; set; }

        public bool PLAYER_LOGGEDON { get; set; }

        public bool PLAYER_INGAME { get; set; }

        public DateTime PLAYER_DATEREGISTERED { get; set; }

        public byte[] PLAYER_AVATAR { get; set; }

        public string PLAYER_AVATARTYPE { get; set; }
    }
}
