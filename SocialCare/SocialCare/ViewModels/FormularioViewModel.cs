using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.ViewModels
{
    public class FormularioViewModel
    {
        public TAB_PACIENTE Paciente { get; set; }
        public TAB_VISITA Visita { get; set; }
        public IQueryable<TAB_VISITA> visitasConcluidas { get; set; }

        public int idPaciente { get; set; }
        public int idProfissional { get; set; }

        public int idFormulario { get; set; }

        public string lstCID10 { get; set; }

        public bool mat_cama { get; set; }
        public bool mat_cadRodas { get; set; }
        public bool mat_cadBanho { get; set; }
        public bool mat_Aspirador { get; set; }
        public bool mat_Inalador { get; set; }
        public bool mat_Colchao { get; set; }
        public bool mat_ConcO2 { get; set; }
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
        public int? grauCE { get; set; }

        public bool UP { get; set; }
        public string momento_UP { get; set; }
        public IEnumerable<SelectListItem> opcoesEstagios { get; set; }
        public string estagio_UP { get; set; }
        public DateTime? data_UP { get; set; }

        public IEnumerable<SelectListItem> opcoesPeriodicidade { get; set; }
        public string periodicidade { get; set; }

        public string lstProcedimento { get; set; }
        public string txtObs { get; set; }        

        public bool saida { get; set; }
        public DateTime? saidaData { get; set; }
        public string saidaMotivo { get; set; }
        public string saidaDescricao { get; set; }
        public IEnumerable<SelectListItem> opcoesMotivoSaida { get; set; }
    }
}