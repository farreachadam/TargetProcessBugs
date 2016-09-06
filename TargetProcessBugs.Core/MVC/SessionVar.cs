using System;
using System.Web;
using System.Web.SessionState;

namespace TargetProcessBugs.Core.MVC
{
    /// <summary>
    /// Encapsulate Session
    /// 
    /// TODO:
    ///    - Add check if T is serializable (applicable if using StateServer)
    /// </summary>
    public class SessionVar
    {
        public static HttpSessionState Session
        {
            get
            {
                if (HttpContext.Current == null) throw new ApplicationException("No HttpContext...unable to retrieve Session!");
                return HttpContext.Current.Session;
            }
        }

        public static T Get<T>(string key)
        {
            if (Session[key] == null)
                return default(T);
            else
                return (T)Session[key];
        }

        public static void Set<T>(string key, T value)
        {
            Session[key] = value;
        }

        #region Getters\Setters for specific types
        
        public static string GetString(string key)
        {
            string s = Get<string>(key);
            return s == null ? string.Empty : s;
        }    
        
        #endregion Getters\Setters for specific types
    }
}
