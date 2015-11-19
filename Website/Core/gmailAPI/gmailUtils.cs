using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.gmailAPI
{
    static public class GmailUtils
    {
        static string[] Scopes = { GmailService.Scope.GmailCompose,
                                 GmailService.Scope.GmailSend, GmailService.Scope.GmailReadonly,GmailService.Scope.MailGoogleCom
                                 };
        static string ApplicationName = "IProtest";

        public static  bool SendMail(string fromMail, string[] toMails, string message, string title, UserCredential cr = null){
            var service = GetGmailService(cr);
            var request = service.Users.Messages.List("me");
            var msg = new Message();
            string body = "To: " + String.Join(",", toMails) + "\n" +
                          "Subject: " + title + "\n\n" + message;
            msg.Raw = EncodeTo64(body);
            var send = service.Users.Messages.Send(msg, fromMail);

            send.Execute();
            return true;
        }

        public static UserCredential GetGmailCredentials()
        {
            UserCredential credential;
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, "credentials");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }
            return credential;
        }

        public static GmailService GetGmailService(UserCredential cr = null){
            UserCredential credential = cr ?? GetGmailCredentials();


            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            return service;
        }

        static public string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }
    }
}
