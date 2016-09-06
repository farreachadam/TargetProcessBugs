using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TargetProcessBugs.Core.MVC;
using TargetProcessBugs.Web.Infrastructure;

namespace TargetProcessBugs.Web.Services
{
    public class BaseService
    {
        public string CurrentUsername
        {
            get
            {
                return SessionVar.GetString(SessionKeys.Username);
            }
        }

        public string CurrentPassword
        {
            get
            {
                return SessionVar.GetString(SessionKeys.Password);
            }
        }
    }
}