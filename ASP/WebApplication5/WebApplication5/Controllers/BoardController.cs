using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult List(int? id)
        {
            // 점검
            if (id == null)
                return HttpNotFound("Error Message #1");
            // return Content("Error Message #1");

            DocumentActs documentActs = new DocumentActs();
            var data = documentActs.GetDocuments();

            return View(data);
        }
    }
}