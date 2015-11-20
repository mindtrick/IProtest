using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [JsonProperty("id")]
        [BsonId]
        public string Id { get; set; }
        [JsonProperty("userCreated")]
        public string UserCreated { get; set; }

        [JsonProperty("creationTime")]
        public DateTime CreationTime { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("about")]
        public string About { get; set; }

        [JsonProperty("images")]
        public IEnumerable<string> Images { get; set; }

        [JsonProperty("links")]
        public IEnumerable<string> Links { get; set; }

        [JsonProperty("activities")]
        public IEnumerable<Activity> Activities { get; set; }

        [JsonProperty("allowedApps")]
        public IEnumerable<ProtestAppContext> AllowedApps { get; set; }

        [BsonIgnore]
        [JsonProperty("apps")]
        public IEnumerable<App> Apps { get; set; }
        
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
