using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Core;
using MongoDB.Bson.Serialization;
using System.Linq.Expressions;
using Dal;

namespace DAL
{
    public class DataManager
    {

        private static DataManager _instance;
        private static object _lock;


        private const string PROTESTS_COLLECTION = "protests";
        private const string USERS_COLLECTION = "users";
        private const string APPS_COLLECTION = "apps";

        static DataManager()
        {
            _lock = new object();
            BsonClassMap.RegisterClassMap<FaceBookUserSettings>();
        }

        private DataManager()
        {

        }

        public static DataManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;

                lock (_lock)
                {
                    return _instance ?? (_instance = new DataManager());
                }
            }
        }

        public Protest GetProtestById(string id)
        {
            return GetCollection<Protest>(PROTESTS_COLLECTION).Find(Builders<Protest>.Filter.Eq(p => p.Id, id)).ToList().FirstOrDefault();
        }

        public IEnumerable<Protest> GetAllProtests()
        {
            return GetCollection<Protest>(PROTESTS_COLLECTION).Find(_ => true).ToList();
        }



        public bool UpdateAppToken(string username, string token, Expression<Func<User, string>> exp)
        {
            var up =
                GetCollection<User>(USERS_COLLECTION).UpdateOne(
                Builders<User>.Filter.Eq(u => u.Username, username),
                Builders<User>.Update.Set(exp, token)
                );

            return up.IsAcknowledged && up.IsModifiedCountAvailable && up.ModifiedCount > 0;
        }


        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("protestsHackathon");
            return db.GetCollection<T>(collectionName);
        }



        public bool UpdateTwitterToken(string username, string token)
        {
            var up =
                GetCollection<User>(USERS_COLLECTION).UpdateOne(
                Builders<User>.Filter.Eq(u => u.Username, username),
                Builders<User>.Update.Set(e => e.TwitterSettings.Token, token)
                );

            return up.IsAcknowledged && up.IsModifiedCountAvailable && up.ModifiedCount > 0;
        }

        public bool UpdateGmailToken(string username, string token)
        {
            var up =
                GetCollection<User>(USERS_COLLECTION).UpdateOne(
                Builders<User>.Filter.Eq(u => u.Username, username),
                Builders<User>.Update.Set(e => e.GmailSettings.Token, token)
                );

            return up.IsAcknowledged && up.IsModifiedCountAvailable && up.ModifiedCount > 0;
        }

        public bool UpdateFacebookToken(string username, string token)
        {
            var up =
                GetCollection<User>(USERS_COLLECTION).UpdateOne(
                Builders<User>.Filter.Eq(u => u.Username, username),
                Builders<User>.Update.Set(e => e.FacebookSettings.Token, token)
                );

            return up.IsAcknowledged && up.IsModifiedCountAvailable && up.ModifiedCount > 0;
        }

        public User GetUserByName(string username)
        {
            return GetCollection<User>(USERS_COLLECTION).Find(Builders<User>.Filter.Eq(p => p.Username, username)).ToList().FirstOrDefault();
        }

        public IEnumerable<App> GetAllApps()
        {
            return GetCollection<App>(APPS_COLLECTION).Find(_ => true).ToList();
        }

        public bool RegisterUser(string username, User.UserProtestContext userProtestContext)
        {            
            var up = GetCollection<User>(USERS_COLLECTION).UpdateOne(
                Builders<User>.Filter.Eq(p => p.Username, username),
                Builders<User>.Update.Set("UserProtestsContext." + userProtestContext.ProtestId, userProtestContext)
                );


            ActivateMethods(username, userProtestContext);
            return up.IsAcknowledged && up.IsModifiedCountAvailable && up.ModifiedCount > 0;
        }

        public bool ActivateMethods(string username, User.UserProtestContext userProtestContext)
        { 
            HashSet<string> appsToActivate = new HashSet<string>();
            var apps = userProtestContext.AvailableApps ?? new List<User.UserAppContext>();
            foreach(var app in apps)
            {
                string appName = app.AppName;
                appsToActivate.Add(appName);
            }

            if(appsToActivate.Contains("Facebook"))
            {
                LogicsExecuter.PostInFacebook(username, userProtestContext.ProtestId);
            }

            if(appsToActivate.Contains("Gmail"))
            {
                LogicsExecuter.SendMail(username, userProtestContext.ProtestId);
            }

            if(appsToActivate.Contains("Twitter"))
            {
                LogicsExecuter.Tweet(username, userProtestContext.ProtestId);
            }

            return true;
        }
    }
}
