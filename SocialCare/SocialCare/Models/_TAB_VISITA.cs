﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    [MetadataType(typeof(TAB_VISITAMetadata))]

    public partial class TAB_VISITA
    {

    }

    public enum EnumStatusVisita
    {
        REALIZADO = 1,
        PENDENTE
    }

    public class TAB_VISITAMetadata
    {
        public int cod_visita { get; set; }
        public int cod_paciente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string dat_visita { get; set; }

        public string des_status { get; set; }
        public int cod_profissional { get; set; }
        public string des_periodicidade { get; set; }
        public string des_obs { get; set; }
    }
}