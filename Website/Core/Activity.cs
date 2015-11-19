using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Activity
    {
        public string Id { get; set; }

        public string User { get; set; }

        public string Message { get; set; }

        public DateTime CreationTime { get; set; }

        public Activity(string user, string message)
        {
            User = user;
            Message = message;
            CreationTime = DateTime.Now;
            Id = ObjectId.GenerateNewId().ToString();
        }
    }
}
