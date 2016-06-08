using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    public class _SocialCare
    {
        SocialCareEntities db = new SocialCareEntities();

        public Tuple<bool,int?> Autenticacao(string login, string senha)
        {
            var user = db.TAB_PROFISSIONAL.Where(model => model.des_login == login && model.des_senha == senha).FirstOrDefault();

            return user == null ? new Tuple<bool, int?>(false, null) : new Tuple<bool, int?>(true, user.cod_profissional);
        }

        public TAB_PROFISSIONAL ObterPorfissional(int idProfissional)
        {
            return db.TAB_PROFISSIONAL.Where(model => model.cod_profissional == idProfissional).FirstOrDefault();
        }

        public IQueryable<TAB_PACIENTE> ObterPacientes()
        {
            return db.TAB_PACIENTE.Where(model => model.TAB_FORM.Count() == 0).AsQueryable();
        }

        public TAB_PACIENTE ObterPaciente(int idPaciente)
        {
            return db.TAB_PACIENTE.Where(model => model.cod_paciente == idPaciente).FirstOrDefault();
        }
    }
}