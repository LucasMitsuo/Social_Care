using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCare.ViewModels
{
    public class FormularioViewModel
    {
        public TAB_PACIENTE Paciente;

        public string lstCID10;

        public bool mat_cama;
        public bool mat_cadRodas;
        public bool mat_cadBanho;
        public bool mat_Aspirador;
        public bool mat_Inalador;
        public bool mat_Colchao;
        public bool mat_Conc02;
        public bool mat_torpTransp;
        public bool mat_Oximetro;
        public bool mat_CPAP;

        public bool proc_Gastro;
        public bool proc_POD;
        public bool proc_SNasoEnteral;
        public bool proc_SVesicalDemora;
        public bool proc_SVesicalInterm;
        public bool proc_Traqueostomia;
    }
}