using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class TwitterUserSettings : BasicUserSettings
    {
        public string Secret { get; set; }

        public TwitterUserSettings()
            : base()
        {
            Secret = Secret ?? string.Empty;
        }
    }
}
