using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SocialCare.Controllers
{
    public class PacientesController : Controller
    {   
        [Route("pacientes")]
        public ActionResult Lista()
        {
            _SocialCare sc = new _SocialCare();
            return View(sc.ObterPacientes());
        }


    }
}