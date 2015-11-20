using MongoDB.Bson.Serialization.Attributes;
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
        public string Username { get; set; }


        public TwitterUserSettings TwitterSettings { get; set; }

        public GmailUserSettings GmailSettings { get; set; }

        public FaceBookUserSettings FacebookSettings { get; set; }

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
