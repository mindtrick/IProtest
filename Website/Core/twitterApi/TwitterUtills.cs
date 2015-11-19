using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            ErrorHandling();
        }

        public void SendTwitt(string twitt)
        {
            _service.SendTweet(new SendTweetOptions() { Status = twitt });
            ErrorHandling();
        }

        public List<TwitterUser> GetFollowers()
        {
            TwitterUser tuSelf = _service.GetUserProfile(
    new GetUserProfileOptions() { IncludeEntities = false, SkipStatus = false });
            //TODO: check if working
            ListFollowersOptions options = new ListFollowersOptions();
            options.UserId = tuSelf.Id;
            options.ScreenName = tuSelf.ScreenName;
            options.IncludeUserEntities = true;
            options.SkipStatus = false;
            options.Cursor = -1;
            List<TwitterUser> lstFollowers = new List<TwitterUser>();

            TwitterCursorList<TwitterUser> followers = _service.ListFollowers(options);

            // if the API call did not succeed
            if (followers == null)
            {
                ErrorHandling();
            }
            else
            {
                while (followers.NextCursor != null)
                {
                    //options.Cursor = followers.NextCursor;
                    //followers = m_twService.ListFollowers(options);

                    // if the API call did not succeed
                    if (followers == null)
                    {
                        ErrorHandling();
                    }
                    else
                    {
                        foreach (TwitterUser user in followers)
                        {
                            // do something with the user (I'm adding them to a List)
                            lstFollowers.Add(user);
                        }
                    }

                    // if there are more followers
                    if (followers.NextCursor != null &&
                        followers.NextCursor != 0)
                    {
                        // then advance the cursor and load the next page of results
                        options.Cursor = followers.NextCursor;
                        followers = _service.ListFollowers(options);
                    }
                    // otherwise, we're done!
                    else
                        break;
                }
            }
            return lstFollowers;
        }

        private void ErrorHandling()
        {
            TwitterError error = _service.Response.Error;
            if (error != null)
            {
                throw new Exception(error.ToString());
            }
        }
    }
}
