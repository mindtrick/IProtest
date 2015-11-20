using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class User
    {
        [BsonId]
        [JsonProperty("username")]
        public string Username { get; set; }


        [JsonProperty("twitterSettings")]
        public TwitterUserSettings TwitterSettings { get; set; }

        [JsonProperty("gmailSettings")]
        public GmailUserSettings GmailSettings { get; set; }

        [JsonProperty("facebookSettings")]
        public FaceBookUserSettings FacebookSettings { get; set; }

        [JsonProperty("userProtestsContext")]
        public Dictionary<string, UserProtestContext> UserProtestsContext { get; set; }

        public User(string username)
        {
            Username = username;
            TwitterSettings = new TwitterUserSettings();
            GmailSettings = new GmailUserSettings();
            FacebookSettings = new FaceBookUserSettings();
            UserProtestsContext = new Dictionary<string, UserProtestContext>();
        }



        public class UserProtestContext
        {
            public string ProtestId { get; set; }

            public IEnumerable<UserAppContext> AvailableApps { get; set; }
        }

        public class UserAppContext
        {
            public string AppName { get; set; }

            public IEnumerable<UserOptionContext> Options { get; set; }
        }

        public class UserOptionContext
        {
            public string Name { get; set; }
            public bool Allowed { get; set; }
        }
    }
}
