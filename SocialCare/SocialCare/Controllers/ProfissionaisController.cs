using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialCare.Models;

namespace SocialCare.Controllers
{
    public class ProfissionaisController : Controller
    {

        [HttpPost]
        [Route("socialcare/login")]
        public ActionResult VerificaLogin(string login, string senha)
        {
            _SocialCare sc = new _SocialCare();

            var result = sc.Autenticacao(login, senha);

            if (!result.Item1)
            {
                ViewBag.ErroLogin = "Login ou senha inválidos";
                return View("~/Views/Home/Login.cshtml");
            }

            return RedirectToAction("Lista", "Visitas", new { identifier = result.Item2 });
        }
    }
}