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
    public class ActivitiesController : ApiController
    {              
        public bool Post([FromUri]string protestId  , [FromBody]Activity activity)
        {
            try
            {
                return DataManager.Instance.SaveActivity(protestId, activity.Clone());
            }
            catch(Exception ex)
            {
                Console.WriteLine("ha ha");
                return false;
            }
        }
    }
}
