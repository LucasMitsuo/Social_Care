using SocialCare.Models;
using SocialCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SocialCare.Controllers
{
    public class FormularioController : Controller
    {
        [Route("profissionais/{idprofissional}/pacientes/{identifier}/prontuario")]
        public ActionResult Detalhes(int identifier,int idprofissional)
        {
            var nois = WebConfigurationManager.AppSettings["PFUserName"];
            _SocialCare sc = new _SocialCare();
            FormularioViewModel model = new FormularioViewModel();

            //Define os dados de Paciente
            var paciente = sc.ObterPaciente(identifier);
            model.Paciente = paciente;
            model.idPaciente = identifier;
            model.idProfissional = idprofissional;

            //Obtém a visita referente ao paciente selecionado e ao profissional logado
            var visita = paciente.TAB_VISITA.Where(x => x.cod_paciente == paciente.cod_paciente && x.cod_profissional == idprofissional).FirstOrDefault();
            model.Visita = visita;

            //Obtém a lista de visitas já concluídas daquele paciente
            model.visitasConcluidas = paciente.TAB_VISITA.Where(p => p.des_status.Equals(((int)EnumStatusVisita.CONCLUIDA).ToString())).AsQueryable();

            model.idFormulario = paciente.TAB_FORM.FirstOrDefault().cod_form;

            //Define os CID10
            #region Define CID10
            foreach (var cid in paciente.TAB_FORM.FirstOrDefault().TAB_DIAGNOSTICO)
            {
                var texto = cid.TAB_CID.cod_cid10 + " - " + cid.TAB_CID.des_cid;
                model.lstCID10 += texto + ";";
            }

            if(model.lstCID10 != null)
            { 
                //Remove o último ';'
                model.lstCID10 = model.lstCID10.Remove(model.lstCID10.LastIndexOf(";"));
            }
            #endregion

            //Define os materiais
            #region Define Materiais
            foreach (var material in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_MAT)
            {
                switch (material.TAB__MATERIAL.nom_material)
                {
                    case "Cama":
                        model.mat_cama = true;
                        break;
                    case "Cadeira de rodas":
                        model.mat_cadRodas = true;
                        break;
                    case "Cadeira de banho":
                        model.mat_cadBanho = true;
                        break;
                    case "Aspirador":
                        model.mat_Aspirador = true;
                        break;
                    case "Inalador":
                        model.mat_Inalador = true;
                        break;
                    case "Colchão":
                        model.mat_Colchao = true;
                        break;
                    case "Conc_O2":
                        model.mat_ConcO2 = true;
                        break;
                    case "Torp_Transp":
                        model.mat_torpTransp = true;
                        break;
                    case "Oxímetro":
                        model.mat_Oximetro = true;
                        break;
                    case "CPAP":
                        model.mat_CPAP = true;
                        break;
                }
            }
            #endregion

            //Define os Procedimentos_Enfermeira
            #region Define os Procedimentos_Enfermeira
            foreach(var procEnf in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_PROC_ENF)
            {
                switch (procEnf.TAB_PROC_ENF.nom_proc_enf)
                {
                    case "Gastro":
                        model.proc_Gastro = true;
                        break;
                    case "POD":
                        model.proc_POD = true;
                        break;
                    case "SNasoEnteral":
                        model.proc_SNasoEnteral = true;
                        break;
                    case "SVesicalDemora":
                        model.proc_SVesicalDemora = true;
                        break;
                    case "SVesicalInterm":
                        model.proc_SVesicalInterm = true;
                        break;
                    case "Traqueostomia":
                        model.proc_Traqueostomia = true;
                        break;

                }
               
            }
            #endregion

            //Define CE
            #region Define CE
            List<object> colCE = new List<object>();

            colCE.Add(new { valor = 0, descricao = "Grau 0" });
            colCE.Add(new { valor = 1, descricao = "Grau 1" });
            colCE.Add(new { valor = 2, descricao = "Grau 2" });
            colCE.Add(new { valor = 3, descricao = "Grau 3" });
            colCE.Add(new { valor = 4, descricao = "Grau 4" });
            colCE.Add(new { valor = 5, descricao = "Grau 5" });

            List<SelectListItem> _opcoesCE = new SelectList(colCE, "valor", "descricao").ToList();
            model.opcoesCE = _opcoesCE;
            model.grauCE = paciente.num_grau_ce.Value;
            #endregion

            //Define UP
            #region Define UP
            if(paciente.TAB_UP.Count() > 0)
            {
                model.UP = true;
                var upPaciente = paciente.TAB_UP.FirstOrDefault();
                model.momento_UP = upPaciente.des_momento;
                model.estagio_UP = upPaciente.des_estagio;
                model.data_UP = upPaciente.dat_up.Value;
            }
            model.data_UP = null;

            List<object> colEstagios = new List<object>();

            colEstagios.Add(new { valor = "Estágio I", descricao = "Estágio I" });
            colEstagios.Add(new { valor = "Estágio II", descricao = "Estágio II" });
            colEstagios.Add(new { valor = "Estágio III", descricao = "Estágio III" });
            colEstagios.Add(new { valor = "Estágio IV", descricao = "Estágio IV" });
            colEstagios.Add(new { valor = "Estágio V", descricao = "Estágio V" });
            colEstagios.Add(new { valor = "Inclassificável", descricao = "Inclassificável" });

            List<SelectListItem> _opcoesEstagios = new SelectList(colEstagios, "valor", "descricao").ToList();
            model.opcoesEstagios = _opcoesEstagios;
            #endregion

            //Define Periodicidade
            #region Define Periodicidade
            List<object> colPeriodicidade = new List<object>();

            colPeriodicidade.Add(new { valor = "Semanal", descricao = "Semanal" });
            colPeriodicidade.Add(new { valor = "Mensal", descricao = "Mensal" });
            colPeriodicidade.Add(new { valor = "Bimestral", descricao = "Bimestral" });
            colPeriodicidade.Add(new { valor = "Trimestral", descricao = "Trimestral" });
            colPeriodicidade.Add(new { valor = "Semestral", descricao = "Semestral" });
            colPeriodicidade.Add(new { valor = "Stand By", descricao = "Stand By" });

            List<SelectListItem> _opcoesPeriodicidade = new SelectList(colPeriodicidade, "valor", "descricao").ToList();
            model.opcoesPeriodicidade = _opcoesPeriodicidade;
            model.periodicidade = visita.des_periodicidade;
            #endregion

            //Define Saida
            #region Define Saída
            if(paciente.TAB_SAIDA.Count() > 0)
            {
                model.saida = true;
                var saidaPaciente = paciente.TAB_SAIDA.FirstOrDefault();
                model.saidaData = saidaPaciente.dat_saida;
                model.saidaMotivo = saidaPaciente.des_razao;
                model.saidaDescricao = saidaPaciente.des_obs;
            }
            else
            {
                model.saidaData = null;
            }

            List<object> colMotivos = new List<object>();

            colMotivos.Add(new { valor = "1", descricao = "Alta" });
            colMotivos.Add(new { valor = "2", descricao = "Óbito" });

            List<SelectListItem> _opcoesMotivos = new SelectList(colMotivos, "valor", "descricao").ToList();
            model.opcoesMotivoSaida = _opcoesMotivos;
            #endregion

            return View(model);
        }

        [Route("pacientes/{identifier}/novoprontuario")]
        public ActionResult Novo (int identifier)
        {
            _SocialCare sc = new _SocialCare();
            FormularioViewModel model = new FormularioViewModel();

            var profissional = Session["usuario"] as TAB_PROFISSIONAL;
            model.idProfissional = profissional.cod_profissional;

            var paciente = sc.ObterPaciente(identifier);
            model.Paciente = paciente;
            model.idPaciente = paciente.cod_paciente;

            //Define CE
            #region Define CE
            List<object> colCE = new List<object>();

            colCE.Add(new { valor = 0, descricao = "Grau 0" });
            colCE.Add(new { valor = 1, descricao = "Grau 1" });
            colCE.Add(new { valor = 2, descricao = "Grau 2" });
            colCE.Add(new { valor = 3, descricao = "Grau 3" });
            colCE.Add(new { valor = 4, descricao = "Grau 4" });
            colCE.Add(new { valor = 5, descricao = "Grau 5" });

            List<SelectListItem> _opcoesCE = new SelectList(colCE, "valor", "descricao").ToList();
            model.opcoesCE = _opcoesCE;
            model.grauCE = null;
            #endregion

            //Define UP
            #region Define UP
            List<object> colEstagios = new List<object>();

            colEstagios.Add(new { valor = "Estágio I", descricao = "Estágio I" });
            colEstagios.Add(new { valor = "Estágio II", descricao = "Estágio II" });
            colEstagios.Add(new { valor = "Estágio III", descricao = "Estágio III" });
            colEstagios.Add(new { valor = "Estágio IV", descricao = "Estágio IV" });
            colEstagios.Add(new { valor = "Estágio V", descricao = "Estágio V" });
            colEstagios.Add(new { valor = "Inclassificável", descricao = "Inclassificável" });

            List<SelectListItem> _opcoesEstagios = new SelectList(colEstagios, "valor", "descricao").ToList();
            model.opcoesEstagios = _opcoesEstagios; 
            #endregion

            return View(model);
        }

        [Route("pacientes/{identifier}/prontuarios/{idProntuario}")]
        public ActionResult Visualizar(int identifier,int idProntuario)
        {
            _SocialCare sc = new _SocialCare();
            FormularioViewModel model = new FormularioViewModel();

            //Define os dados de Paciente
            var paciente = sc.ObterPaciente(identifier);
            model.Paciente = paciente;
            model.idPaciente = identifier;

            //Obtém a lista de visitas já concluídas daquele paciente
            model.visitasConcluidas = paciente.TAB_VISITA.Where(p => p.des_status.Equals(((int)EnumStatusVisita.CONCLUIDA).ToString())).AsQueryable();

            model.idFormulario = paciente.TAB_FORM.FirstOrDefault().cod_form;

            //Define os CID10
            #region Define CID10
            foreach (var cid in paciente.TAB_FORM.FirstOrDefault().TAB_DIAGNOSTICO)
            {
                var texto = cid.TAB_CID.cod_cid10 + " - " + cid.TAB_CID.des_cid;
                model.lstCID10 += texto + ";";
            }

            if (model.lstCID10 != null)
            {
                //Remove o último ';'
                model.lstCID10 = model.lstCID10.Remove(model.lstCID10.LastIndexOf(";"));
            }
            #endregion

            //Define os materiais
            #region Define Materiais
            foreach (var material in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_MAT)
            {
                switch (material.TAB__MATERIAL.nom_material)
                {
                    case "Cama":
                        model.mat_cama = true;
                        break;
                    case "Cadeira de rodas":
                        model.mat_cadRodas = true;
                        break;
                    case "Cadeira de banho":
                        model.mat_cadBanho = true;
                        break;
                    case "Aspirador":
                        model.mat_Aspirador = true;
                        break;
                    case "Inalador":
                        model.mat_Inalador = true;
                        break;
                    case "Colchão":
                        model.mat_Colchao = true;
                        break;
                    case "Conc_O2":
                        model.mat_ConcO2 = true;
                        break;
                    case "Torp_Transp":
                        model.mat_torpTransp = true;
                        break;
                    case "Oxímetro":
                        model.mat_Oximetro = true;
                        break;
                    case "CPAP":
                        model.mat_CPAP = true;
                        break;
                }
            }
            #endregion

            //Define os Procedimentos_Enfermeira
            #region Define os Procedimentos_Enfermeira
            foreach (var procEnf in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_PROC_ENF)
            {
                switch (procEnf.TAB_PROC_ENF.nom_proc_enf)
                {
                    case "Gastro":
                        model.proc_Gastro = true;
                        break;
                    case "POD":
                        model.proc_POD = true;
                        break;
                    case "SNasoEnteral":
                        model.proc_SNasoEnteral = true;
                        break;
                    case "SVesicalDemora":
                        model.proc_SVesicalDemora = true;
                        break;
                    case "SVesicalInterm":
                        model.proc_SVesicalInterm = true;
                        break;
                    case "Traqueostomia":
                        model.proc_Traqueostomia = true;
                        break;

                }

            }
            #endregion

            //Define CE
            #region Define CE
            List<object> colCE = new List<object>();

            colCE.Add(new { valor = 0, descricao = "Grau 0" });
            colCE.Add(new { valor = 1, descricao = "Grau 1" });
            colCE.Add(new { valor = 2, descricao = "Grau 2" });
            colCE.Add(new { valor = 3, descricao = "Grau 3" });
            colCE.Add(new { valor = 4, descricao = "Grau 4" });
            colCE.Add(new { valor = 5, descricao = "Grau 5" });

            List<SelectListItem> _opcoesCE = new SelectList(colCE, "valor", "descricao").ToList();
            model.opcoesCE = _opcoesCE;
            model.grauCE = paciente.num_grau_ce.Value;
            #endregion

            //Define UP
            #region Define UP
            if (paciente.TAB_UP.Count() > 0)
            {
                model.UP = true;
                var upPaciente = paciente.TAB_UP.FirstOrDefault();
                model.momento_UP = upPaciente.des_momento;
                model.estagio_UP = upPaciente.des_estagio;
                model.data_UP = upPaciente.dat_up.Value;
            }

            List<object> colEstagios = new List<object>();

            colEstagios.Add(new { valor = "Estágio I", descricao = "Estágio I" });
            colEstagios.Add(new { valor = "Estágio II", descricao = "Estágio II" });
            colEstagios.Add(new { valor = "Estágio III", descricao = "Estágio III" });
            colEstagios.Add(new { valor = "Estágio IV", descricao = "Estágio IV" });
            colEstagios.Add(new { valor = "Estágio V", descricao = "Estágio V" });
            colEstagios.Add(new { valor = "Inclassificável", descricao = "Inclassificável" });

            List<SelectListItem> _opcoesEstagios = new SelectList(colEstagios, "valor", "descricao").ToList();
            model.opcoesEstagios = _opcoesEstagios;
            #endregion

            //Define Periodicidade
            #region Define Periodicidade
            List<object> colPeriodicidade = new List<object>();

            colPeriodicidade.Add(new { valor = "Semanal", descricao = "Semanal" });
            colPeriodicidade.Add(new { valor = "Mensal", descricao = "Mensal" });
            colPeriodicidade.Add(new { valor = "Bimestral", descricao = "Bimestral" });
            colPeriodicidade.Add(new { valor = "Trimestral", descricao = "Trimestral" });
            colPeriodicidade.Add(new { valor = "Semestral", descricao = "Semestral" });
            colPeriodicidade.Add(new { valor = "Stand By", descricao = "Stand By" });

            List<SelectListItem> _opcoesPeriodicidade = new SelectList(colPeriodicidade, "valor", "descricao").ToList();
            model.opcoesPeriodicidade = _opcoesPeriodicidade;
            #endregion

            //Define Saida
            #region Define Saída
            if (paciente.TAB_SAIDA.Count() > 0)
            {
                model.saida = true;
                var saidaPaciente = paciente.TAB_SAIDA.FirstOrDefault();
                model.saidaData = saidaPaciente.dat_saida;
                model.saidaMotivo = saidaPaciente.des_razao;
                model.saidaDescricao = saidaPaciente.des_obs;
            }
            else
            {
                model.saidaData = null;
            }

            List<object> colMotivos = new List<object>();

            colMotivos.Add(new { valor = "1", descricao = "Alta" });
            colMotivos.Add(new { valor = "2", descricao = "Óbito" });

            List<SelectListItem> _opcoesMotivos = new SelectList(colMotivos, "valor", "descricao").ToList();
            model.opcoesMotivoSaida = _opcoesMotivos;
            #endregion

            return View(model);
        }
    }
}