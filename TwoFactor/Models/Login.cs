using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Authenticator;

namespace TwoFactor.Models
{
    public class Login
    {
        //public string qrImage { get; set; }
        //public string inputCode { get; set; }

        public SetupCode Generate { get; set; }
        public string email { get; set; }
        public string pin { get; set; }
    }
}