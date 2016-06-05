using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.Controllers
{
    public class VisitasController : Controller
    {
        [HttpPost]
        public ActionResult Lista()
        {
            return View();
        }
    }
}