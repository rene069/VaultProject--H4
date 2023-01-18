using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class PassVault
    {
        public string AppName { get; set; }

        public string PassSalt { get; set; }

        public string Passhash { get; set; }


        public User User { get; set; }
    }
}
