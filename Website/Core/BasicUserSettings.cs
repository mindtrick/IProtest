using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class BasicUserSettings
    {

        public string Token { get; set; }

        public string Name { get; set; }

        public BasicUserSettings()
        {
            Token = Token ?? string.Empty;
            Name = Name ?? string.Empty;
        }
    }
}
