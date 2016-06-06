using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    [MetadataType(typeof(TAB_PROFISSIONALMetadata))]
    public partial class TAB_PROFISSIONAL
    {
        
    }
    
    public class TAB_PROFISSIONALMetadata
    {
        public int cod_profissional { get; set; }
        public string nom_profissional { get; set; }

        [Display(Name = "Login")]
        public string des_login { get; set; }

        [Display(Name = "Senha")]
        public string des_senha { get; set; }
        public string des_cargo { get; set; }
        public string num_rg { get; set; }
        public string dat_nascimento { get; set; }
        public string des_email { get; set; }
        public string dat_admissao { get; set; }
        public string dat_demissao { get; set; }
        public string des_sexo { get; set; }
        public int num_end { get; set; }
        public string des_complemento_end { get; set; }
        public string des_referencia_end { get; set; }
        public string img_foto { get; set; }
    }
}