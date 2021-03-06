﻿using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.Controllers
{
    public class VisitasController : Controller
    {
        [Route("profissionais/{identifier}/visitas")]
        public ActionResult Lista(int identifier)
        {
            _SocialCare sc = new _SocialCare();

            var profissional = sc.ObterProfissional(identifier);
            Session["usuario"] = profissional;

            var statusPendente = ((int)EnumStatusVisita.PENDENTE).ToString();

            //Captura somente as visitas que estejam pendentes
            var visitas = profissional.TAB_VISITA.Where(model => model.des_status.Equals(statusPendente));

            return View(visitas.AsQueryable());
        }
    }
}