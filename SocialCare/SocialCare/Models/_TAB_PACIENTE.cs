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
        SocialCareEntities db = new SocialCareEntities();

        /// <summary>
        /// Idade do Paciente
        /// </summary>
        public int Idade
        {
            get
            {
                return (DateTime.Now - this.dat_nasc).Days / 365;
            }
        }

        /// <summary>
        /// Verifica se o Paciente possui ou não um prontuário
        /// </summary>
        public bool PossuiFormulario
        {
            get
            {
                return this.TAB_FORM.Count() > 0 ? true : false;
            }
        }

        /// <summary>
        /// Altera os dados em relação à Úlcera por Pressão
        /// </summary>
        /// <param name="tabUp"></param>
        public void AlteraUP(TAB_UP tabUp)
        {
            var UP = db.TAB_UP.Where(model => model.cod_paciente == this.cod_paciente).FirstOrDefault();

            UP.des_momento = tabUp.des_momento;
            UP.des_estagio = tabUp.des_estagio;
            UP.dat_up = tabUp.dat_up;

            db.SaveChanges();
        }
        
        /// <summary>
        /// Exclui os dados em relação a Ulcera por Pressão
        /// </summary>
        public void ExcluiUP()
        {
            db.TAB_UP.Remove(db.TAB_UP.Where(model => model.cod_paciente == this.cod_paciente).FirstOrDefault());
            db.SaveChanges();
        }

        /// <summary>
        /// Cadastra os dados em relação a Úlcera por Pressão
        /// </summary>
        /// <param name="tabup"></param>
        public void CadastraUP(TAB_UP tabup)
        {
            tabup.cod_paciente = this.cod_paciente;

            db.TAB_UP.Add(tabup);
            db.SaveChanges();
        }

        /// <summary>
        /// Exclui as informações referentes a saída do Paciente
        /// </summary>
        public void ExcluiSaida()
        {
            db.TAB_SAIDA.Remove(db.TAB_SAIDA.Where(model => model.cod_paciente == this.cod_paciente).FirstOrDefault());
            db.SaveChanges();
        }

        /// <summary>
        /// Adiciona informações relacionada a Saída do Paciente
        /// </summary>
        /// <param name="tabSaida"></param>
        public void AdicionaSaida(TAB_SAIDA tabSaida)
        {
            tabSaida.cod_paciente = this.cod_paciente;

            db.TAB_SAIDA.Add(tabSaida);
            db.SaveChanges();
        }

        /// <summary>
        /// Cria um formulário para o paciente
        /// </summary>
        /// <returns></returns>
        public TAB_FORM CriarFormulario()
        {
            var novoFormulario = new TAB_FORM()
            {
                cod_paciente = this.cod_paciente
            };

            db.TAB_FORM.Add(novoFormulario);
            db.SaveChanges();

            return novoFormulario;
        }

        /// <summary>
        /// Altera o grau CE do paciente
        /// </summary>
        /// <param name="grauCE"></param>
        public void AlteraCE(int grauCE)
        {
            var paciente = db.TAB_PACIENTE.Where(model => model.cod_paciente == this.cod_paciente).FirstOrDefault();
            paciente.num_grau_ce = grauCE;
            db.SaveChanges();
        }

        /// <summary>
        /// Cria um novo UP caso o paciente tenha úlcera por pressão
        /// </summary>
        /// <param name="dadosUP">Objeto contendo dados de UP</param>
        /// <returns></returns>
        public void CriaUP(TAB_UP dadosUP)
        {
            var novoUP = new TAB_UP()
            {
                des_momento = dadosUP.des_momento,
                des_estagio = dadosUP.des_estagio,
                dat_up = dadosUP.dat_up,
                cod_paciente = this.cod_paciente
            };

            db.TAB_UP.Add(novoUP);
            db.SaveChanges();
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