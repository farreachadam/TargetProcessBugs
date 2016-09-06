using System.Configuration;

namespace TargetProcessBugs.Web.Infrastructure
{
    /// <summary>
    /// Static class for accessing config values
    /// </summary>
    public static class Config
    {
        //
        // Web.config App Settings
        //
        public static string TargetProcessBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["targetProcessBaseUrl"];
            }
        }

        public static string AuthenticateSalt
        {
            get
            {
                return ConfigurationManager.AppSettings["authenticateSalt"];
            }
        }        
    }


}