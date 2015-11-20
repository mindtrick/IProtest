using Core.twitterApi;
using FacebookApi;
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

            TwitterUtills utils = new TwitterUtills();

            utils.Authenticate("4227119651-PQuBHMjdY3IE3ncIJaCSK85AVRK3vxJPsRuQAKM", "aOXXVhWoafpabXSodUBb7Kn0SxxTl2OhnUjMvvn7Cwgy5");
            utils.SendTwitt("liad is a kakamaika boy");
        }
    }
}
