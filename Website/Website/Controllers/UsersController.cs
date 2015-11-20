using Core;
using DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website.Controllers
{
    public class UsersController : ApiController
    {

        public User Get(string username)
        {
            try
            {
                return DataManager.Instance.GetUserByName(username);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [ActionName("updateUserTokenOfFacebook")]
        public bool PostUpdateUserTokenOfFacebook([FromBody]TokenUserContext context)
        {
            try
            {
                return DataManager.Instance.UpdateFacebookToken(context.UserName, context.Token);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("updateUserTokenOfGmail")]
        public bool PostUpdateUserTokenOfGmail([FromBody]TokenUserContext context)
        {
            try
            {
                return DataManager.Instance.UpdateGmailToken(context.UserName, context.Token);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("updateUserTokenOfTwitter")]
        public bool PostUpdateUserTokenOfTwitter([FromBody]TokenUserContext context)
        {
            try
            {
                return DataManager.Instance.UpdateTwitterToken(context.UserName, context.Token);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [ActionName("registerUser")]
        public bool PostRegisterUser([FromBody]UserProtestRegistrationContext context)
        {
            try
            {
                return DataManager.Instance.RegisterUser(context.UserName, context.UserProtestContext);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        [ActionName("sendMessage")]
        public bool PostSendMessage(UserSendMessageContext context)
        {
            try
            {
                return DataManager.Instance.SendMessage(context.Message, context.ProtestId);
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public class UserSendMessageContext
        {
            public string Message { get; set; }

            public string ProtestId { get; set; }
        }


        public class TokenUserContext
        {
            public string UserName { get; set; }

            public string Token { get; set; }
        }

        public class UserProtestRegistrationContext
        {
            public string UserName { get; set; }

            public Core.User.UserProtestContext UserProtestContext { get; set; }
        }
    }
}
