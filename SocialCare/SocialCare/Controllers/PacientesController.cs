﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Lista()
        {
            return View();
        }
    }
}