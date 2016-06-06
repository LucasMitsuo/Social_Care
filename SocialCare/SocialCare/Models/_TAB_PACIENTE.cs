using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    [MetadataType(typeof(TAB_PACIENTEMetadata))]
    public partial class TAB_PACIENTE
    {
    }

    public class TAB_PACIENTEMetadata
    {
        public int cod_paciente { get; set; }
        public string nom_paciente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public string dat_nasc { get; set; }

        public string tel_paciente { get; set; }
        public string des_sexo { get; set; }
        public string des_end { get; set; }
        public int num_end { get; set; }
        public string des_referencia_end { get; set; }
        public string Nom_cuidador { get; set; }
        public string des_parentesco { get; set; }
        public int? num_grau_ce { get; set; }
    }
}