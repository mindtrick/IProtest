using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
        public class GmailUserSettings : BasicUserSettings
        {
            public UserCredential GoogleToken { get; set; }

            public GmailUserSettings(UserCredential token = null, string email = null)
                : base()
            {
                GoogleToken = token ?? null;
                Name = email ?? null;
            }
        }
}
