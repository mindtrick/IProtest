using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class App
    {
        [BsonId]
        public string Name { get; set; }

        public IEnumerable<string> Options { get; set; }

        public App()
        {
            Options = Options != null ? Options.Distinct() : new List<string>(); 
        }
    }
}
