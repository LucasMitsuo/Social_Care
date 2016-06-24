using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    public class DadosNovoProntuario
    {
        /// <summary>
        /// Número identificador do paciente
        /// </summary>
        public int idPaciente { get; set; }

        /// <summary>
        /// String contendo todos os CID´s do Paciente
        /// </summary>
        public string lstCID10 { get; set; }

        // Dados relativo aos materiais
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

        //Dados relativos aos procedimentos Enfermeira
        public bool proc_Gastro { get; set; }
        public bool proc_POD { get; set; }
        public bool proc_SNasoEnteral { get; set; }
        public bool proc_SVesicalDemora { get; set; }
        public bool proc_SVesicalInterm { get; set; }
        public bool proc_Traqueostomia { get; set; }

        /// <summary>
        /// Grau do CE
        /// </summary>
        public int grauCE { get; set; }

        /// <summary>
        /// Boolean que indica se o paciente tem UP 
        /// </summary>
        public bool UP { get; set; }

        public string momento_UP { get; set; }
        public string estagio_UP { get; set; }
        public DateTime data_UP { get; set; }
    }
}