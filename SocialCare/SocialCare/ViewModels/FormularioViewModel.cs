using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.ViewModels
{
    public class FormularioViewModel
    {
        public TAB_PACIENTE Paciente { get; set; }

        public string lstCID10 { get; set; }

        public bool mat_cama { get; set; }
        public bool mat_cadRodas { get; set; }
        public bool mat_cadBanho { get; set; }
        public bool mat_Aspirador { get; set; }
        public bool mat_Inalador { get; set; }
        public bool mat_Colchao { get; set; }
        public bool mat_Conc02 { get; set; }
        public bool mat_torpTransp { get; set; }
        public bool mat_Oximetro { get; set; }
        public bool mat_CPAP { get; set; }

        public bool proc_Gastro { get; set; }
        public bool proc_POD { get; set; }
        public bool proc_SNasoEnteral { get; set; }
        public bool proc_SVesicalDemora { get; set; }
        public bool proc_SVesicalInterm { get; set; }
        public bool proc_Traqueostomia { get; set; }

        public IEnumerable<SelectListItem> opcoesCE { get; set; }
        public int grauCE { get; set; }
    }
}