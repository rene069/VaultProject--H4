﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class User
    {
        public string UserName { get; set; }
        public string PassHash { get; set; }
        public string PassSalt { get; set; }


        public List<PassVault> passVaults { get; set; }

        public List<FileVault> fileVaults { get; set; }
        
    }
}
