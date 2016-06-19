using SocialCare.Models;
using SocialCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialCare.Controllers
{
    public class FormularioController : Controller
    {
        [Route("profissionais/{idprofissional}/pacientes/{identifier}/prontuario")]
        public ActionResult Detalhes(int identifier,int idprofissional)
        {
            _SocialCare sc = new _SocialCare();
            FormularioViewModel model = new FormularioViewModel();

            //Define os dados de Paciente
            var paciente = sc.ObterPaciente(identifier);
            model.Paciente = paciente;
            model.idPaciente = identifier;
            model.idProfissional = idprofissional;

            var visita = paciente.TAB_VISITA.Where(x => x.cod_paciente == paciente.cod_paciente && x.cod_profissional == idprofissional).FirstOrDefault();
            model.Visita = visita;

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
                        model.mat_Conc02 = true;
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
            colPeriodicidade.Add(new { valor = "Stand By", descricao = "Stando By" });

            List<SelectListItem> _opcoesPeriodicidade = new SelectList(colPeriodicidade, "valor", "descricao").ToList();
            model.opcoesPeriodicidade = _opcoesPeriodicidade;
            model.periodicidade = visita.des_periodicidade;
            #endregion



            return View(model);
        }

        [Route("pacientes/{identifier}/novoprontuario")]
        public ActionResult Novo (int identifier)
        {
            _SocialCare sc = new _SocialCare();
            FormularioViewModel model = new FormularioViewModel();

            var paciente = sc.ObterPaciente(identifier);
            model.Paciente = paciente;

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

        [HttpPost]
        public ActionResult Create(FormularioViewModel dadosFormulario)
        {
            _SocialCare sc = new _SocialCare();
            var paciente = sc.ObterPaciente(1);
            var formulario = paciente.TAB_FORM.FirstOrDefault();

            #region CID10
            string lstCID10 = "";

            // Obtem lista de CID10
            foreach (var cid in paciente.TAB_FORM.FirstOrDefault().TAB_DIAGNOSTICO)
            {
                var texto = cid.TAB_CID.cod_cid10 + " - " + cid.TAB_CID.des_cid;
                lstCID10 += texto + ";";
            }

            // Obtem a lista com as alterações do CID10
            var lstNovaCID10 = dadosFormulario.lstCID10;

            if(lstNovaCID10 != null)
            { 
                string[] strlstNovaCID10 = lstNovaCID10.Split(';');

                for (var i = 0; i < strlstNovaCID10.Length - 1; i++)
                {
                    // Comparando a lista de cid10 nova com os dados do banco
                    if (lstCID10.Contains(strlstNovaCID10[i]))
                    {

                        lstCID10 = lstCID10.Replace(strlstNovaCID10[i] + ";", "");
                    }
                    else
                    {
                        // Obtem o código do CID10 inserido e passa como parametro para o método AdicionaCID10
                        formulario.AdicionaCID10(strlstNovaCID10[i].Substring(0, strlstNovaCID10[i].IndexOf('-')-1));
                    }
                                   

                }
            }
            string[] strlstVelhaCID10 = lstCID10.Split(';');

            for (var i = 0; i < strlstVelhaCID10.Length-1; i++ )
            {
                
                formulario.ExcluiCID10(strlstVelhaCID10[i].Substring(0, strlstVelhaCID10[i].IndexOf('-') - 1));
            }



            #endregion

            #region Materiais
            string materiais = "";

            //Obtém todos os materiais do paciente e seta a string
            foreach(var material in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_MAT)
            {
                materiais += material.TAB__MATERIAL.nom_material + ";";
            }

            if (dadosFormulario.mat_cama)
            {
                if (!materiais.Contains("Cama"))
                {
                    formulario.AdicionaMaterial("Cama");
                }
                else
                { 
                    materiais = materiais.Replace("Cama;", "");
                }
            }

            if (dadosFormulario.mat_cadRodas)
            {
                if (!materiais.Contains("Cadeira de rodas"))
                {
                    formulario.AdicionaMaterial("Cadeira de rodas");
                }
                else
                {
                    materiais = materiais.Replace("Cadeira de rodas;", "");
                }
            
            }

            if (dadosFormulario.mat_cadBanho)
            {
                if (!materiais.Contains("Cadeira de banho"))
                {
                    formulario.AdicionaMaterial("Cadeira de banho");
                }
                else
                {
                    materiais = materiais.Replace("Cadeira de banho;", "");
                }

            }

            if (dadosFormulario.mat_Aspirador)
            {
                if (!materiais.Contains("Aspirador"))
                {
                    formulario.AdicionaMaterial("Aspirador");
                }
                else
                {
                    materiais = materiais.Replace("Aspirador;", "");
                }

            }

            if (dadosFormulario.mat_Inalador)
            {
                if (!materiais.Contains("Inalador"))
                {
                    formulario.AdicionaMaterial("Inalador");
                }
                else
                {
                    materiais = materiais.Replace("Inalador;", "");
                }

            }

            if (dadosFormulario.mat_Colchao)
            {
                if (!materiais.Contains("Colchão"))
                {
                    formulario.AdicionaMaterial("Colchão");
                }
                else
                {
                    materiais = materiais.Replace("Colchão;", "");
                }

            }

            if (dadosFormulario.mat_Conc02)
            {
                if (!materiais.Contains("Conc_02"))
                {
                    formulario.AdicionaMaterial("Conc_02");
                }
                else
                {
                    materiais = materiais.Replace("Conc_02;", "");
                }

            }

            if (dadosFormulario.mat_torpTransp)
            {
                if (!materiais.Contains("Torp_Transp"))
                {
                    formulario.AdicionaMaterial("Torp_Transp");
                }
                else
                {
                    materiais = materiais.Replace("Torp_Transp;", "");
                }

            }

            if (dadosFormulario.mat_Oximetro)
            {
                if (!materiais.Contains("Oxímetro"))
                {
                    formulario.AdicionaMaterial("Oxímetro");
                }
                else
                {
                    materiais = materiais.Replace("Oxímetro;", "");
                }

            }

            if (dadosFormulario.mat_CPAP)
            {
                if (!materiais.Contains("CPAP"))
                {
                    formulario.AdicionaMaterial("CPAP");
                }
                else
                {
                    materiais = materiais.Replace("CPAP;", "");
                }

            }

            string[] lstMateriais = materiais.Split(';');

            for(var i = 0;i < lstMateriais.Length - 1 ; i++)
            {
                formulario.ExcluiMaterial(lstMateriais[i]);
            }



            #endregion

            #region Obs Enfermeira

            string obsEnfermeira = "";

            foreach (var i in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_PROC_ENF)
            {
                obsEnfermeira += i.TAB_PROC_ENF.nom_proc_enf + ";";
            }

            if (dadosFormulario.proc_Gastro)
            {
                if (!obsEnfermeira.Contains("Gastro"))
                {
                    formulario.AdicionaObsEnfermeira("Gastro");
                }
                else
                {
                    obsEnfermeira = obsEnfermeira.Replace("Gastro;", "");
                }
            }

            if (dadosFormulario.proc_POD)
            {
                if (!obsEnfermeira.Contains("POD"))
                {
                    formulario.AdicionaObsEnfermeira("POD");
                }
                else
                {
                    obsEnfermeira = obsEnfermeira.Replace("POD;", "");
                }
            }

            if (dadosFormulario.proc_SNasoEnteral)
            {
                if (!obsEnfermeira.Contains("SNasoEnteral"))
                {
                    formulario.AdicionaObsEnfermeira("SNasoEnteral");
                }
                else
                {
                    obsEnfermeira = obsEnfermeira.Replace("SNasoEnteral;", "");
                }
            }


            if (dadosFormulario.proc_SVesicalDemora)
            {
                if (!obsEnfermeira.Contains("SVesicalDemora"))
                {
                    formulario.AdicionaObsEnfermeira("SVesicalDemora");
                }
                else
                {
                    obsEnfermeira = obsEnfermeira.Replace("SVesicalDemora;", "");
                }
            }

            if (dadosFormulario.proc_SVesicalInterm)
            {
                if (!obsEnfermeira.Contains("SVesicalInterm"))
                {
                    formulario.AdicionaObsEnfermeira("SVesicalInterm");
                }
                else
                {
                    obsEnfermeira = obsEnfermeira.Replace("VesicalInterm;", "");
                }
            }
            
            if (dadosFormulario.proc_Traqueostomia)
            {
                if (!obsEnfermeira.Contains("Traqueostomia"))
                {
                    formulario.AdicionaObsEnfermeira("Traqueostomia");
                }
                else
                {
                    obsEnfermeira = obsEnfermeira.Replace("Traqueostomia;", "");
                }
            }

            string[] lstProcEnfermeira = obsEnfermeira.Split(';');

            for (var i = 0; i < lstProcEnfermeira.Length - 1; i++)
            {
                formulario.ExcluiObsEnfermeira(lstProcEnfermeira[i]);
            }


            #endregion

            #region UP

            var UP_BD = paciente.TAB_UP.Count > 0 ? true : false;
            
            if(UP_BD && dadosFormulario.UP)
            {
                var novoUP = new TAB_UP()
                {
                    des_momento = dadosFormulario.momento_UP,
                    des_estagio = dadosFormulario.estagio_UP,
                    dat_up = dadosFormulario.data_UP
                };

                paciente.AlteraUP(novoUP);
            }
            else if (UP_BD)
            {
                paciente.ExcluiUP();
            }
            else if(dadosFormulario.UP)
            {
                var novoUP = new TAB_UP()
                {
                    des_momento = dadosFormulario.momento_UP,
                    des_estagio = dadosFormulario.estagio_UP,
                    dat_up = dadosFormulario.data_UP
                };

                paciente.CadastraUP(novoUP);

            }
            
            #endregion

            return View();
        }
    }
}