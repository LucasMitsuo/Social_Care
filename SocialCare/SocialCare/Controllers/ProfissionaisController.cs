using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SocialCare.Models;
using SocialCare.ViewModels;

namespace SocialCare.Controllers
{
    public class ProfissionaisController : Controller
    {

        [HttpPost]
        [Route("login")]
        public ActionResult VerificaLogin(LoginViewModel dadosLogin)
        {
            if (ModelState.IsValid)
            { 
                _SocialCare sc = new _SocialCare();

                var result = sc.Autenticacao(dadosLogin.login, dadosLogin.senha);

                if (!result.Item1)
                {
                    ViewBag.ErroLogin = "Login ou senha inválidos";
                    return View("~/Views/Home/Login.cshtml");
                }

                return RedirectToAction("Lista", "Visitas", new { identifier = result.Item2 });
            }
            else
            {
                return View("~/Views/Home/Login.cshtml");
            }
        }
    }
}