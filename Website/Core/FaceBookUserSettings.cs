using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class FaceBookUserSettings : BasicUserSettings
    {
        public string Image { get; set; }

        public FaceBookUserSettings() : base()
        {
            Image = Image ?? string.Empty;
        }
    }
}
