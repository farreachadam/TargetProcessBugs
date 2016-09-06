using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TargetProcessBugs.Core;
using TargetProcessBugs.Core.MVC;
using TargetProcessBugs.Web.Infrastructure;

namespace TargetProcessBugs.Web.Services
{
    public class BaseService
    {
        public RestClient TargetProcessRestClient()
        {
            var client = new RestClient(Config.TargetProcessBaseUrl);
            client.Authenticator = TargetProcessAuthenticator();

            return client;
        }

        private IAuthenticator TargetProcessAuthenticator()
        {
            var cookie = HttpContext.Current?.Request?.Cookies["targetProcessBugsAuthentication"];
            if (cookie != null)
            {
                var cookieToken = Util.Base64Decode(cookie.Value);
                var data = cookieToken.Split('|');
                return new HttpBasicAuthenticator(data[0], data[1]);
            }

            throw new Exception("Not authorized");
        }
    }
}