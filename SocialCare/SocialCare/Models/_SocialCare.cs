using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    public class _SocialCare
    {
        SocialCareEntities db = new SocialCareEntities();

        /// <summary>
        /// Obtem uma visita de acordo com o id do profissional e o id do paciente e o status pendente.
        /// </summary>
        /// <param name="idPaciente">número identificador do paciente</param>
        /// <param name="idProfissional">número identificar do profissional</param>
        /// <returns></returns>
        public TAB_VISITA ObterVisita(int idPaciente, int idProfissional)
        {
            var statusPendente = ((int)EnumStatusVisita.PENDENTE).ToString();
            var visita = db.TAB_VISITA.Where(model => model.cod_paciente == idPaciente && model.cod_profissional == idProfissional && model.des_status == statusPendente).FirstOrDefault();
            return visita;
        }

        /// <summary>
        /// Autentica o profissional 
        /// </summary>
        /// <param name="login">login do profissional</param>
        /// <param name="senha">senha do profissional</param>
        /// <returns></returns>
        public Tuple<bool,int?> Autenticacao(string login, string senha)
        {
            var user = db.TAB_PROFISSIONAL.Where(model => model.des_login == login && model.des_senha == senha).FirstOrDefault();

            return user == null ? new Tuple<bool, int?>(false, null) : new Tuple<bool, int?>(true, user.cod_profissional);
        }

        /// <summary>
        /// Obtem um profissional por id
        /// </summary>
        /// <param name="idProfissional">Número identificadro do profissional</param>
        /// <returns></returns>
        public TAB_PROFISSIONAL ObterProfissional(int idProfissional)
        {
            return db.TAB_PROFISSIONAL.Where(model => model.cod_profissional == idProfissional).FirstOrDefault();
        }
        
        /// <summary>
        /// Obtém todos os pacientes do sistema
        /// </summary>
        /// <returns></returns>
        public IQueryable<TAB_PACIENTE> ObterPacientes()
        {
            return db.TAB_PACIENTE.AsQueryable();
        }

        /// <summary>
        /// Obtém um paciente por id
        /// </summary>
        /// <param name="idPaciente">Número identificador do paciente</param>
        /// <returns></returns>
        public TAB_PACIENTE ObterPaciente(int idPaciente)
        {
            return db.TAB_PACIENTE.Where(model => model.cod_paciente == idPaciente).FirstOrDefault();
        }

        /// <summary>
        /// Obtém uma lista de visitas de acordo com o intervalo de datas
        /// </summary>
        /// <param name="dataInicial">Data inicial</param>
        /// <param name="dataFinal">Data Final</param>
        /// <returns></returns>
        public IQueryable<TAB_VISITA> ObterVisitas(string dataInicial,string dataFinal)
        {
            DateTime _dataInicial = Convert.ToDateTime(dataInicial);
            DateTime _dataFinal = Convert.ToDateTime(dataFinal);
            var lstVisitas = db.TAB_VISITA.Where(model => model.dat_visita >= _dataInicial && model.dat_visita <= _dataFinal);

            return lstVisitas;
        }
    }
}