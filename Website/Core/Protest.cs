using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Protest
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonId]
        public string Id { get; set; }

        public string UserCreated { get; set; }

        public DateTime CreationTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string About { get; set; }

        public IEnumerable<string> Images { get; set; }

        public IEnumerable<string> Links { get; set; }

        public IEnumerable<Activity> Activities { get; set; }

        public IEnumerable<ProtestAppContext> AllowedApps { get; set; }

        public class ProtestAppContext
        {
            public string Name {get; set;}

            public IEnumerable<string> AvailableOptions {get; set;}
        }
        

        public Protest()
        {
            CreationTime = DateTime.Now;
            Activities = new List<Activity>();
            Links = new List<string>();
            Images = new List<string>();
            AllowedApps = new List<ProtestAppContext>();
        }
    }
}
