using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TargetProcessBugs.Core.MVC;
using TargetProcessBugs.Web.Infrastructure;
using TargetProcessBugs.Web.Infrastructure.Filters;
using TargetProcessBugs.Web.Models;
using TargetProcessBugs.Core.MVC.Alerts;
using RestSharp.Authenticators;
using TargetProcessBugs.Core;
using TargetProcessBugs.Web.Services;

namespace TargetProcessBugs.Web.Controllers
{
    [AuthenticatedFilter]
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult apiPoc()
        {
            // projects
            // teams
            // owner (logged in person)
            // description

            var service = new PocService();
            var projects = service.GetProjects();
            
            var vm = new ApiPocViewModel();
            vm.Projects = projects.Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        #region Login\Authentication

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            //https://www.targetprocess.com/guide/faq/rest-api-authentication/   
            var vm = new LoginViewModel()
            {
                Username = "adam@farreachinc.com",
                Password = ""
            };

            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View(vm);
            }
            
            var client = new RestClient(Config.TargetProcessBaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(vm.Username, vm.Password);
            
            var request = new RestRequest("Userstories");
            var response = client.Execute(request);
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return RedirectToAction("Login").WithError("Couldn't authenticate you: " + response.StatusDescription);
            }

            // create authentication token
            var token = Util.Base64Encode($"{vm.Username}|{vm.Password}|{Config.AuthenticateSalt}");

            // add authorization cookie
            var cookie = new System.Web.HttpCookie("targetProcessBugsAuthentication");
            cookie.Value = token;
            cookie.Expires = DateTime.Now.AddDays(14);
            Response.Cookies.Add(cookie);

                        
            return RedirectToAction("Index");
        }

        #endregion Login\Authentication
    }
}