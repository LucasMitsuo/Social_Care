using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    [MetadataType(typeof(TAB_VISITAMetadata))]

    public partial class TAB_VISITA
    {
        SocialCareEntities db = new SocialCareEntities();
        public string ProcedimentoObs
        {
            get
            {
                string result = "";
                foreach(var item in this.TAB_VISITA_PROC)
                {
                    result += item.TAB_PROCEDIMENTO.nom_procedimento + " - " + item.TAB_PROCEDIMENTO.obs_procedimento + ";";
                }

                return result + "\n" + this.des_obs;
            }
        }

        /// <summary>
        /// Cadastra Procedimento 
        /// </summary>
        /// <param name="procedimento">Procedimento</param>

        public void CadastrarProcedimento(string procedimento)
        {
            //Obtem o procedimento pelo parametro 
            var proc = db.TAB_PROCEDIMENTO.Where(model => model.nom_procedimento.Equals(procedimento)).FirstOrDefault();
            //Cria um novo objeto TAB_VISITA_PROC com os ids certinho
            var novoProc = new TAB_VISITA_PROC()
            {
                cod_procedimento = proc.cod_procedimento,
                cod_visita = this.cod_visita
            };
            //add e save changes
            db.TAB_VISITA_PROC.Add(novoProc);
            db.SaveChanges();
        }

        /// <summary>
        /// Atualiza a visita com a periodicidade, obs e status
        /// </summary>
        /// <param name="peridiocidade"> Periodicidade</param>
        /// <param name="obs">Observação</param>
        /// <param name="status">Status</param>
        public void AlteraVisita (string peridiocidade, string obs)
        {
            var visita = db.TAB_VISITA.Where(model => model.cod_visita == this.cod_visita).FirstOrDefault();
            visita.des_periodicidade = peridiocidade;
            visita.des_status = ((int)EnumStatusVisita.CONCLUIDA).ToString();
            visita.des_obs = obs;
            db.SaveChanges();
        }
    }

    public class TAB_VISITAMetadata
    {
        public int cod_visita { get; set; }
        public int cod_paciente { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime dat_visita { get; set; }

        public string des_status { get; set; }
        public int cod_profissional { get; set; }
        public string des_periodicidade { get; set; }
        public string des_obs { get; set; }
    }

    public enum EnumStatusVisita
    {
        CONCLUIDA = 1,
        PENDENTE
    }
}