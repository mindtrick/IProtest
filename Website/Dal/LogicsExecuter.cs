using Core.gmailAPI;
using Core.twitterApi;
using DAL;
using FacebookApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Configuration;

namespace Dal
{
    public class LogicsExecuter
    {

        static LogicsExecuter()
        {
            HARDCORE_USERS = new string[]
            {
                "ramatz777@gmail.com",
                "liad.roz@gmail.com",
                "mindtrick67@gmail.com",
                "‫vsh1818@gmail.com"
            };

            WEB_SITE_ADDRESS = ConfigurationManager.AppSettings["websiteLink"] ?? string.Empty;
        }

        private static string CreateMessage(string protestId)
        {

            return string.Format(WEB_SITE_ADDRESS, protestId);
        }

        public static bool Tweet(string username, string protestId)
        {
            try
            {
                var user = DataManager.Instance.GetUserByName(username);

                var twitterSettings = user.TwitterSettings;

                var secret = twitterSettings.Secret;

                var token = twitterSettings.Token;

                var utils = new TwitterUtills();

                utils.Authenticate(token, secret);

                utils.SendTwitt(CreateMessage(protestId));

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static bool PostInFacebook(string username, string protestId)
        {

            try
            {
                var user = DataManager.Instance.GetUserByName(username);

                var facebookToken = user.FacebookSettings.Token;

                new FBApi().Post(new List<string> { facebookToken }, CreateMessage(protestId));

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        //fromMail -> me
        public static bool SendMail(string username, string protestId)
        {
            try
            {
                var user = DataManager.Instance.GetUserByName(username);
                var protest = DataManager.Instance.GetProtestById(protestId);
                GmailUtils.SendMail(user.GmailSettings.Mail, HARDCORE_USERS, CreateMessage(protestId), string.Format("IProtest : join protest {0}", protest.Title));
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static string[] HARDCORE_USERS { get; private set; }

        public static string WEB_SITE_ADDRESS { get; private set; }
    }
}
