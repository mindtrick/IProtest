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

        public IEnumerable<Option> Options { get; set; }

        public App()
        {
            Options = Options = Options ??  new List<Option>(); 
        }

        public class Option
        {
            public string Name { get; set; }

            public string Description { get; set; }
        }
    }
}
