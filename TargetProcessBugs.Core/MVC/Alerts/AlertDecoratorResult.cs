﻿using System.Web.Mvc;

namespace TargetProcessBugs.Core.MVC.Alerts
{
    public class AlertDecoratorResult : ActionResult
    {
        public AlertDecoratorResult(ActionResult innerResult,
            string alertClass,
            string message)
        {
            InnerResult = innerResult;
            AlertClass = alertClass;
            Message = message;
        }

        public ActionResult InnerResult { get; set; }
        public string AlertClass { get; set; }
        public string Message { get; set; }

        public override void ExecuteResult(ControllerContext context)
        {
            var alerts = context.Controller.TempData.GetAlerts();
            alerts.Add(new Alert(AlertClass, Message));

            InnerResult.ExecuteResult(context);
        }
    }
}
