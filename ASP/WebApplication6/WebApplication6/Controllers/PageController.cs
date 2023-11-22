using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Controllers
{
    public class PageController : Controller
    {
        // GET: Page
        public ActionResult ShowInfo()
        {
            return View();
        }
    }
}