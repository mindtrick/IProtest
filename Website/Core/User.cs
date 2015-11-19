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


        public BasicUserSettings TwitterSettings { get; set; }

        public BasicUserSettings GmailSettings { get; set; }

        public FaceBookUserSettings FacebookSettings { get; set; }

        public IEnumerable<string> RegisteredProtests { get; set; }

        public User(string username)
        {
            Username = username;
            TwitterSettings = new BasicUserSettings();
            GmailSettings = new BasicUserSettings();
            FacebookSettings = new FaceBookUserSettings();
            RegisteredProtests = new List<string>();
        }
    }
}
