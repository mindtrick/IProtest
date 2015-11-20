using Google.Apis.Auth.OAuth2;
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

            string email = "ramatz777@gmail.com";
            //user.GmailSettings = 
            //var mon = new MongoClient();
            //GmailUserSettings loaded = mon.GetDatabase("protestsHackathon").GetCollection<GmailUserSettings>("credentials").Find<GmailUserSettings>(x => x.Name == "vsh1818@gmail.com").ToListAsync().Wait();
            //User loaded = mon.GetDatabase("protestsHackathon")
            //    .GetCollection<User>("users").Find(Builders<User>.Filter.Eq(p => p.Username, email)).ToListAsync().Result.FirstOrDefault();
            //if (loaded==null)
            //{
            //    User user = new User(email);
                UserCredential cr = gmailAPI.GmailUtils.GetGmailCredentials();
             //   GmailUserSettings gcr = new GmailUserSettings(cr, email);
           //     user.GmailSettings = gcr;
            //    mon.GetDatabase("protestsHackathon").GetCollection<User>("users").InsertOneAsync(user).Wait();
          //      loaded = mon.GetDatabase("protestsHackathon")
          //      .GetCollection<User>("users").Find(Builders<User>.Filter.Eq(p => p.Username, email)).ToListAsync().Result.FirstOrDefault();
         //   }
            gmailAPI.GmailUtils.SendMail(email, new[] { "vsh1818@gmail.com" }, "fuck you", "you", cr);

          //  var mon = new MongoClient();
          //  User user = new User("758amirm");
          //  mon.GetDatabase("protestsHackathon").GetCollection<User>("users").InsertOneAsync(user).Wait();


            //var mon = new MongoClient();
            //App app = new App() { Name = "dsfs", Options = new List<Core.App.Option> { new Core.App.Option { Description = "SDAS", Name = "sada" } } };
            //mon.GetDatabase("protestsHackathon").GetCollection<App>("apps").InsertOneAsync(app).Wait();
        }
    }
}
