using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            //var mon = new MongoClient();
            //Protest p = new Protest() { Title = "test", Description = "my test description" };
            //mon.GetDatabase("protestsHackathon").GetCollection<Protest>("protests").InsertOneAsync(p).Wait();


            var mon = new MongoClient();
            User user = new User("758amirm");
            mon.GetDatabase("protestsHackathon").GetCollection<User>("users").InsertOneAsync(user).Wait();
        }
    }
}
