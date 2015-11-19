using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BasicUserSettings
    {
        public string Name { get; set; }

        public string Token { get; set; }

        public BasicUserSettings()
        {
            Name = Name ?? string.Empty;
            Token = Token ?? string.Empty;
        }
    }
}
