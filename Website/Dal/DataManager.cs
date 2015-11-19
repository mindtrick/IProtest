using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using Core;

namespace DAL
{
    public class DataManager
    {

        private static DataManager _instance;
        private static object _lock;


        private const string PROTESTS_COLLECTION = "protest";

        static DataManager()
        {
            _lock = new object();
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

        public bool SaveActivity(string protestId, Activity activity)
        {
            var u = GetCollection<Protest>(PROTESTS_COLLECTION).UpdateOne(
                Builders<Protest>.Filter.Eq(p => p.Id, protestId),
                Builders<Protest>.Update.AddToSet(p => p.Activities, activity));

            return u.IsAcknowledged && u.IsModifiedCountAvailable && u.ModifiedCount > 0;
        }

        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("protestsHackathon");
            return db.GetCollection<T>(collectionName);
        }
    }
}
