using System;
using System.Web.Mvc;

namespace RegressionUI.Controllers
{
    public class BaseController : Controller
    {
        public string UserName
        {
            get { return Session["UserName"] == null ? string.Empty : Convert.ToString(Session["UserName"]); }
            set { Session["UserName"] = value; }
        }

        public Int32 UserID
        {
            get { return Session["UserID"] == null ? 0: Convert.ToInt32(Session["UserID"]); }
            set { Session["UserID"] = value; }
        }

    }
}