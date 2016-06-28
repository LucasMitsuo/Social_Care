using SocialCare.DTO;
using SocialCare.Models;
using SocialCare.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Transactions;

namespace SocialCare.Controllers
{

    public class ServicosController : ApiController
    {
        SocialCareEntities db = new SocialCareEntities();

        /// <summary>
        /// Rota que obtém todos os CID10
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/cid10")]
        public HttpResponseMessage ObterCID10()
        {
            var result = db.TAB_CID.ToList();

            var colCID10 = from c in result select new CID10Dto(c).descricao;

            return Request.CreateResponse(HttpStatusCode.OK, colCID10.ToArray());
        }

        /// <summary>
        /// Rota que obtém todos os procedimentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/procedimentos")]
        public HttpResponseMessage ObterProcedimentos()
        {
            var result = db.TAB_PROCEDIMENTO.ToList();

            var colProcedimentos = from p in result select new ProcedimentoDto(p).descricao;

            return Request.CreateResponse(HttpStatusCode.OK, colProcedimentos.ToArray());
        }

        /// <summary>
        /// Edita os dados do formulário de um paciente
        /// </summary>
        /// <param name="idPaciente">Número identificador do paciente</param>
        /// <param name="dadosFormulario">Objeto contendo os dados do formulário</param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/pacientes/{idPaciente}/prontuario")]
        public HttpResponseMessage SalvarDadosProntuario (int idPaciente, FormularioViewModel dadosFormulario)
        {
            try
            {
                _SocialCare sc = new _SocialCare();
                var paciente = sc.ObterPaciente(idPaciente);
                var formulario = paciente.TAB_FORM.FirstOrDefault();
                var visita = sc.ObterVisita(idPaciente, dadosFormulario.idProfissional);

                using (var tx = new TransactionScope())
                {
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

                    if (lstNovaCID10 != null)
                    {
                        string[] strlstNovaCID10 = lstNovaCID10.Split(';');
                        strlstNovaCID10 = strlstNovaCID10.Distinct().ToArray();
                        for (var i = 0; i < strlstNovaCID10.Length; i++)
                        {
                            if (strlstNovaCID10[i] != "")
                            {
                                // Comparando a lista de cid10 nova com os dados do banco
                                if (lstCID10.Contains(strlstNovaCID10[i]))
                                {
                                    lstCID10 = lstCID10.Replace(strlstNovaCID10[i] + ";", "");
                                }
                                else
                                {
                                    // Obtem o código do CID10 inserido e passa como parametro para o método AdicionaCID10
                                    formulario.AdicionaCID10(strlstNovaCID10[i].Substring(0, strlstNovaCID10[i].IndexOf('-') - 1));
                                }
                            }
                        }
                    }
                    string[] strlstVelhaCID10 = lstCID10.Split(';');

                    if(strlstVelhaCID10.Length > 0)
                    { 
                        for (var i = 0; i < strlstVelhaCID10.Length; i++)
                        {
                            if (strlstVelhaCID10[i] != "")
                            {
                                formulario.ExcluiCID10(strlstVelhaCID10[i].Substring(0, strlstVelhaCID10[i].IndexOf('-') - 1));
                            }
                        }
                    }


                    #endregion

                    #region Materiais
                    string materiais = "";

                    //Obtém todos os materiais do paciente e seta a string
                    foreach (var material in paciente.TAB_FORM.FirstOrDefault().TAB_FORM_MAT)
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

                    if (dadosFormulario.mat_ConcO2)
                    {
                        if (!materiais.Contains("Conc_O2"))
                        {
                            formulario.AdicionaMaterial("Conc_O2");
                        }
                        else
                        {
                            materiais = materiais.Replace("Conc_O2;", "");
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

                    for (var i = 0; i < lstMateriais.Length; i++)
                    {
                        if (lstMateriais[i] != "")
                        {
                            formulario.ExcluiMaterial(lstMateriais[i]);
                        }
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
                            obsEnfermeira = obsEnfermeira.Replace("SVesicalInterm;", "");
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

                    for (var i = 0; i < lstProcEnfermeira.Length; i++)
                    {
                        if (lstProcEnfermeira[i] != "")
                        {
                            formulario.ExcluiObsEnfermeira(lstProcEnfermeira[i]);
                        }
                    }

                    //Define o CE
                    if (paciente.num_grau_ce != dadosFormulario.grauCE)
                    {
                        paciente.AlteraCE(dadosFormulario.grauCE.Value);
                    }
                    #endregion

                    #region UP

                    var UP_BD = paciente.TAB_UP.Count > 0 ? true : false;

                    if (UP_BD && dadosFormulario.UP)
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
                    else if (dadosFormulario.UP)
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

                    #region Visita

                    if(dadosFormulario.lstProcedimento != null)
                    { 
                        string[] arrayProc = dadosFormulario.lstProcedimento.Split(';');
                        if (arrayProc != null)
                        {

                            for (var i = 0; i < arrayProc.Length; i++)
                            {
                                if (arrayProc[i] != "")
                                {
                                    visita.CadastrarProcedimento(arrayProc[i].Substring(0, arrayProc[i].IndexOf('-') - 1));

                                }
                            }
                        }
                    }

                    visita.AlteraVisita(dadosFormulario.periodicidade, dadosFormulario.txtObs);

                    #endregion

                    #region Saída
                    var saida = paciente.TAB_SAIDA.Count() > 0 ? true : false;

                    //Verifica se o paciente já tinha uma saída no BD e se foi alterado no formulário
                    if (saida && dadosFormulario.saida)
                    {
                        paciente.ExcluiSaida();

                        var novaSaida = new TAB_SAIDA()
                        {
                            dat_saida = dadosFormulario.saidaData.Value,
                            des_razao = dadosFormulario.saidaMotivo,
                            des_obs = dadosFormulario.saidaDescricao
                        };

                        paciente.AdicionaSaida(novaSaida);
                    }
                    else //Entrará no else se for registrado uma nova saída a partir do formulário
                    {
                        if (dadosFormulario.saida)
                        {
                            var novaSaida = new TAB_SAIDA()
                            {
                                dat_saida = dadosFormulario.saidaData.Value,
                                des_razao = dadosFormulario.saidaMotivo,
                                des_obs = dadosFormulario.saidaDescricao
                            };

                            paciente.AdicionaSaida(novaSaida);
                        }
                    }
                    tx.Complete();
                }
                #endregion
                return Request.CreateResponse(HttpStatusCode.Created, "Prontuário salvo com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro interno.");
            }
        }

        /// <summary>
        /// Rota que salva os dados do novo prontuário no banco
        /// </summary>
        /// <param name="idPaciente">Número identificador do paciente</param>
        /// <param name="dadosProntuario">Objeto contendo os dados do prontuário</param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/pacientes/{idPaciente}/prontuario")]
        public HttpResponseMessage IniciarProntuario(int idPaciente, DadosNovoProntuario dadosProntuario)
        {
            _SocialCare sc = new _SocialCare();
            try
            {
                var paciente = sc.ObterPaciente(idPaciente);

                using(var tx = new TransactionScope())
                {
                    //Cria o formulário
                    var formulario = paciente.CriarFormulario();

                    // Obtem a lista com as alterações do CID10
                    var lstNovaCID10 = dadosProntuario.lstCID10;

                    //Rotina para salvar os CID10
                    if (lstNovaCID10 != null)
                    {
                        string[] strlstNovaCID10 = lstNovaCID10.Split(';');
  
                        for (var i = 0; i < strlstNovaCID10.Length; i++)
                        {
                            if(strlstNovaCID10[i] != "")
                            { 
                                // Obtem o código do CID10 inserido e passa como parametro para o método AdicionaCID10
                                formulario.AdicionaCID10(strlstNovaCID10[i].Substring(0, strlstNovaCID10[i].IndexOf('-') - 1));
                            }
                        }
                    }

                    //Rotina para adicionar os materiais
                    if (dadosProntuario.mat_cama)
                    {
                        formulario.AdicionaMaterial("Cama");
                    }

                    if (dadosProntuario.mat_cadRodas)
                    {
                        formulario.AdicionaMaterial("Cadeira de rodas");
                    }

                    if (dadosProntuario.mat_cadBanho)
                    {                    
                        formulario.AdicionaMaterial("Cadeira de banho");
                    }

                    if (dadosProntuario.mat_Aspirador)
                    {
                        formulario.AdicionaMaterial("Aspirador");
                    }

                    if (dadosProntuario.mat_Inalador)
                    {
                        formulario.AdicionaMaterial("Inalador");
                    }

                    if (dadosProntuario.mat_Colchao)
                    {
                        formulario.AdicionaMaterial("Colchão");
                    }

                    if (dadosProntuario.mat_ConcO2)
                    {
                        formulario.AdicionaMaterial("Conc_O2");
                    }

                    if (dadosProntuario.mat_torpTransp)
                    {
                        formulario.AdicionaMaterial("Torp_Transp");                    
                    }

                    if (dadosProntuario.mat_Oximetro)
                    {
                        formulario.AdicionaMaterial("Oxímetro");
                    }

                    if (dadosProntuario.mat_CPAP)
                    {                
                        formulario.AdicionaMaterial("CPAP");
                    }

                    //Rotina para criar as observações enfermeira
                    if (dadosProntuario.proc_Gastro)
                    {
                        formulario.AdicionaObsEnfermeira("Gastro");
                    }

                    if (dadosProntuario.proc_POD)
                    {                   
                        formulario.AdicionaObsEnfermeira("POD");                   
                    }

                    if (dadosProntuario.proc_SNasoEnteral)
                    {
                        formulario.AdicionaObsEnfermeira("SNasoEnteral");                   
                    }


                    if (dadosProntuario.proc_SVesicalDemora)
                    {                   
                        formulario.AdicionaObsEnfermeira("SVesicalDemora");                   
                    }

                    if (dadosProntuario.proc_SVesicalInterm)
                    {                   
                        formulario.AdicionaObsEnfermeira("SVesicalInterm");                 
                    }

                    if (dadosProntuario.proc_Traqueostomia)
                    {                    
                        formulario.AdicionaObsEnfermeira("Traqueostomia");                    
                    }

                    //Define o CE
                    paciente.AlteraCE(dadosProntuario.grauCE);

                    if (dadosProntuario.UP)
                    {
                        var dadosUP = new TAB_UP()
                        {
                            des_momento = dadosProntuario.momento_UP,
                            des_estagio = dadosProntuario.estagio_UP,
                            dat_up = dadosProntuario.data_UP
                        };

                        paciente.CriaUP(dadosUP);
                    }
                    tx.Complete();
                }

                return Request.CreateResponse(HttpStatusCode.Created, "Prontuário salvo com sucesso");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro interno.");
            }
        }

        [HttpGet]
        [Route("api/visitas/export")]
        public HttpResponseMessage Exportar (string param1, string param2)
        {
            try
            {
                _SocialCare sc = new _SocialCare();
                var sb = new System.Text.StringBuilder();
                sb.Append("\xfeff");

                string str = string.Empty;
                var visitas = sc.ObterVisitas(param1, param2);

                if(visitas.Count() <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Não há visitas nesse intervalo de datas");
                }

                var colunas = new string[] { "Data da Visita", "Código do Paciente", "Nome do Paciente", "Nome do Profissional", "Procedimentos","Observação" };
                foreach(var col in colunas)
                {
                    sb.Append(str + col);
                    str = ";";
                }

                sb.Append("\n");
                foreach(var v in visitas)
                {
                    sb.Append(v.dat_visita.ToString("dd/MM/yyyy"));
                    sb.Append(";" + v.TAB_PACIENTE.cod_paciente);
                    sb.Append(";" + v.TAB_PACIENTE.nom_paciente);
                    sb.Append(";" + v.TAB_PROFISSIONAL.nom_profissional);
                    sb.Append(";" + v.Procedimentos);
                    sb.Append(";" + v.des_obs);
                    sb.Append("\n");
                }

                sb.Append("\n");
                sb.Append("Visitas de " + param1 + " até " + param2);

                var result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StringContent(sb.ToString());
                result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/vnd.ms-excel");
                result.Content.Headers.ContentDisposition.FileName = "Visitas " + param1 + "_" + param2 + ".xls";

                return result;
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("api/checknetwork")]
        public HttpResponseMessage IsConnected()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Tem internet");
        }
    }
}
