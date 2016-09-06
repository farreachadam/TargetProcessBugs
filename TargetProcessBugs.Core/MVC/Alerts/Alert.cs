﻿
namespace TargetProcessBugs.Core.MVC.Alerts
{

    public class Alert
    {
        public Alert(string alertClass, string message)
        {
            AlertClass = alertClass;
            Message = message;
        }

        public string AlertClass { get; set; }
        public string Message { get; set; }
    }
}