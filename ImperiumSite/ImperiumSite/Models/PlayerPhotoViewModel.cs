using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Models
{
    public class PlayerPhotoViewModel
    {
        public int PLAYER_ID { get; set; }

        public byte[] PLAYER_AVATAR { get; set; }

        public string PLAYER_AVATARTYPE { get; set; }
    }
}
