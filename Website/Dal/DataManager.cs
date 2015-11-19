using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

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

        // Global API

        /// <summary>
        /// Update all the PENDING transactions that are expired to CANCELD
        /// </summary>
        public void SyncTransactions()
        {
            throw new System.NotImplementedException();
            // TODO: return the money to the donor
        }


        private IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            var client = new MongoClient();
            var db = client.GetDatabase("mastercard");
            return db.GetCollection<T>(collectionName);
        }
    }
}
