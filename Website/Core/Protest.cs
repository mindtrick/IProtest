using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Protest
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string About { get; set; }

        public IEnumerable<string> Images { get; set; }

        public IEnumerable<string> Links { get; set; }

        public IEnumerable<Activity> Activities { get; set; }
    }
}
