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
    public class AppsController : ApiController
    {
        public IEnumerable<App> Get()
        {
            try
            {
                return DataManager.Instance.GetAllApps();
            }
            catch(Exception)
            {
                return null;
            }
        }
    }
}
