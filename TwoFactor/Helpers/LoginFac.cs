using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Google.Authenticator;

namespace TwoFactor.Helpers
{
    public class LoginFac
    {
        private string UserCode(string email)
        {
            string code;
            code = Crypto.SHA1(email).ToLower();
            
            return code.Substring(0,10);
        }
        public SetupCode CreateTwo(string email)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            SetupCode setupInfo = tfa.GenerateSetupCode("Hest", email, UserCode(email), 300, 300);

            return setupInfo;
        }

        public bool Validate(string email,string pin)
        {
            TwoFactorAuthenticator tfa = new TwoFactorAuthenticator();
            bool isCorrectPin = tfa.ValidateTwoFactorPIN(UserCode(email), pin);

            return isCorrectPin;
        }
    }
}