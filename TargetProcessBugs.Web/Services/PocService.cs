using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TargetProcessBugs.Models;
using TargetProcessBugs.Web.Infrastructure;

namespace TargetProcessBugs.Web.Services
{
    public class PocService : BaseService
    {
        
        public List<Project> GetProjects()
        {
            var client = new RestClient(Config.TargetProcessBaseUrl);
            client.Authenticator = new HttpBasicAuthenticator(CurrentUsername, CurrentPassword);

            // make a request to retrieve projects
            var request = new RestRequest("Projects");
            var response = client.Execute(request);
            if (response.StatusCode != HttpStatusCode.OK) return null;

            // parse the json
            dynamic data = JObject.Parse(response.Content);

            // iterate through json and pull out project info
            var projects = new List<Project>();
            foreach(var project in data.Items)
            {
                projects.Add(new Project
                {
                    Id = project.Id,
                    Name = project.Name,
                    Abbreviation = project.Abbreviation
                });
            }

            return projects;
        }
    }
}