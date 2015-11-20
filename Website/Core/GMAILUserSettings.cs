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
            public string Mail { get; set; }

            public GmailUserSettings(string email = null)
                : base()
            {
                Mail = email ?? string.Empty;
            }
        }
}
