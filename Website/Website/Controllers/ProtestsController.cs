using Core;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Website.Controllers
{
    public class ProtestsController : ApiController
    {
        public Protest Get(string id)
        {
            try
            {
                return DataManager.Instance.GetProtestById(id);
            }
            catch(Exception ex)
            {
                Console.WriteLine("ha ha");
                return null;
            }
        }
    }
}
