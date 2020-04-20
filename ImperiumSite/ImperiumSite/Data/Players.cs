using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Data
{
    [Table("Players")]
    public class Players
    {
        [Key]
        public int PLAYER_ID { get; set; }

        public string PLAYER_USERNAME { get; set; }

        public byte[] PLAYER_AVATAR { get; set; }

        public string PLAYER_AVATARTYPE { get; set; }

        public string PLAYER_PASSWORD { get; set; }

        public int PLAYER_PASSWORDCOUNT { get; set; }

        public string PLAYER_EMAIL { get; set; }

        public bool PLAYER_LOGGEDON { get; set; }

        public bool PLAYER_INGAME { get; set; }

        public DateTime PLAYER_DATEREGISTERED { get; set; }
    }
}
