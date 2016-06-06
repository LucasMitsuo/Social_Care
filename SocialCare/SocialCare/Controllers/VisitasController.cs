using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.Controllers
{
    public class VisitasController : Controller
    {
        [Route("socialcare/visitas")]
        public ActionResult Lista(int identifier)
        {
            _SocialCare sc = new _SocialCare();

            var profissional = sc.ObterPorfissional(identifier);
            Session["usuario"] = profissional;

            //Captura somente as visitas que estejam pendentes e cujo paciente possua formulário
            var visitas = profissional.TAB_VISITA.Where(model => model.des_status.Equals(((int)EnumStatusVisita.PENDENTE).ToString()) && model.TAB_PACIENTE.TAB_FORM.Count() > 0);

            return View(visitas.AsQueryable());
        }
    }
}