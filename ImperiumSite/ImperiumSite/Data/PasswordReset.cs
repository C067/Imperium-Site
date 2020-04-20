using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ImperiumSite.Data
{
    [Table("PasswordReset")]
    public class PasswordReset
    {
        [Key]
        public int PASSWORDRESET_ID { get; set; }

        public string EMAIL { get; set; }

        public string TOKEN { get; set; }

        public DateTime TOKENEXPIRY { get; set; }

        public bool VERIFIED { get; set; }
    }
}
