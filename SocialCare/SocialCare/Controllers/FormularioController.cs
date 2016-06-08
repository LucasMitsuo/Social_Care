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
        public ActionResult Detalhes(int identifier)
        {
            _SocialCare sc = new _SocialCare();
            FormularioViewModel model = new FormularioViewModel();

            //Define os dados de Paciente
            var paciente = sc.ObterPaciente(identifier);
            model.Paciente = paciente;

            //Define os CID10
            #region Define CID10
            foreach(var cid in paciente.TAB_FORM.FirstOrDefault().TAB_DIAGNOSTICO)
            {
                var texto = cid.TAB_CID.cod_cid10 + " - " + cid.TAB_CID.des_cid;
                model.lstCID10 += texto + ";";
            }
            //Remove o último ';'
            model.lstCID10 = model.lstCID10.Remove(model.lstCID10.LastIndexOf(";"));

            #endregion

            //Define os materiais
            #region Define Materiais
            foreach(var material in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_MAT)
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

            return View(model);
        }
    }
}