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
        public IEnumerable<Protest> Get()
        {
            try
            {
                return DataManager.Instance.GetAllProtests();
            }
            catch(Exception ex)
            {
                Console.WriteLine("ha ha");
                return null;
            }
        }

        public Protest Get(string id)
        {
            try
            {
                var p =  DataManager.Instance.GetProtestById(id);
                return p;
            }
            catch(Exception ex)
            {
                Console.WriteLine("ha ha");
                return null;
            }
        }
    }
}
