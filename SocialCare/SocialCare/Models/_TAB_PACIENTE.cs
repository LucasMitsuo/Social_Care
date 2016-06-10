using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    [MetadataType(typeof(TAB_PACIENTEMetadata))]
    public partial class TAB_PACIENTE
    {
        public int Idade
        {
            get
            {
                return (DateTime.Now - this.dat_nasc).Days / 365;
            }
        }

        public bool PossuiFormulario
        {
            get
            {
                return this.TAB_FORM.Count() > 0 ? true : false;
            }
        }
           
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

    public enum Enum_CE
    {
        [Description("Grau 0")]
        Grau0 = 0,

        [Description("Grau 1")]
        Grau1,

        [Description("Grau 2")]
        Grau2,

        [Description("Grau 3")]
        Grau3,

        [Description("Grau 4")]
        Grau4,

        [Description("Grau 5")]
        Grau5
    }
}