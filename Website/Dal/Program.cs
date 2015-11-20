using Core;
using Core.twitterApi;
using FacebookApi;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    class Program
    {
        static void Main(string[] args)
        {
            //FBApi api = new FBApi();
            //api.Post(new List<string> {"CAANbHt07g04BAE94YzPWLfg7UX2V2HpZCZA9jta7qBYFCDuKmkvdt7m0qkmeQs2Bx2Msc8T9phglowxURtpufvuYq5OTvYaCCC6slZCXnEAjR79aA8iqkeYXe3l4aLw5sVrqS4FXOnQ9iNLR5gBdlZCrvehnyz075ZAM6MTsjGlALZAxVxwaOU5TgS74I9qVcm15dELB5ZCB3q72vbnKmyZC"},
            //    "yeled kakamaika");

            //TwitterUtills utils = new TwitterUtills();

            //utils.Authenticate("4227119651-PQuBHMjdY3IE3ncIJaCSK85AVRK3vxJPsRuQAKM", "aOXXVhWoafpabXSodUBb7Kn0SxxTl2OhnUjMvvn7Cwgy5");
            //utils.SendTwitt("liad is a kakamaika boy");


            //var mon = new MongoClient("mongodb://iprotest.cloudapp.net:27017");
            //Protest p = new Protest() { Title = "test", Description = "my test description" };
            //mon.GetDatabase("protestsHackathon").GetCollection<Protest>("protests").InsertOneAsync(p).Wait();

            var mon = new MongoClient("mongodb://iprotest.cloudapp.net:27017");
            User user = new User("ramatz777@gmail.com");
            mon.GetDatabase("protestsHackathon").GetCollection<User>("users").InsertOneAsync(user).Wait();

            //var mon = new MongoClient("mongodb://iprotest.cloudapp.net:27017");
            //var app = new App() { Name = "Twitter", Options = new List<Core.App.Option> { new Core.App.Option { Name = "allow posts on your behalf", Description = "hi liad" } } };
            //mon.GetDatabase("protestsHackathon").GetCollection<App>("apps").InsertOneAsync(app).Wait();

        }
    }
}
