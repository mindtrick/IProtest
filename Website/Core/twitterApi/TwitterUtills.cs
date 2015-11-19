using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetSharp;

namespace Core.twitterApi
{
    class TwitterUtills
    {
        private const string CONSUMER_KEY = "BvjJPDCccXjVJSNnmJUEqKYxC";
        private const string CONSUMER_SECERT = "Qz7xaW4xmsEmAm2jUPJVfUwxloeRrMwQJOq3KoblEp8768BvXA";

        private TwitterService _service = new TwitterService(CONSUMER_KEY, CONSUMER_SECERT);

        public TwitterUtills()
	    {

	    }

        public void Authenticate(string accessToken, string accessSecret)
        {
            _service.AuthenticateWith(accessToken, accessSecret);
        }

        public void SendTwitt(string twitt)
        {
            _service.SendTweet(new SendTweetOptions() { Status = twitt });
        }
    }
}
