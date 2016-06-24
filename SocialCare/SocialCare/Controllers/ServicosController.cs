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

        [HttpGet]
        [Route("api/cid10")]
        public HttpResponseMessage ObterCID10()
        {
            var result = db.TAB_CID.ToList();

            var colCID10 = from c in result select new CID10Dto(c).descricao;

            return Request.CreateResponse(HttpStatusCode.OK, colCID10.ToArray());
        }

        [HttpGet]
        [Route("api/procedimentos")]
        public HttpResponseMessage ObterProcedimentos()
        {
            var result = db.TAB_PROCEDIMENTO.ToList();

            var colProcedimentos = from p in result select new ProcedimentoDto(p).descricao;

            return Request.CreateResponse(HttpStatusCode.OK, colProcedimentos.ToArray());
        }

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

                        for (var i = 0; i < strlstNovaCID10.Length - 1; i++)
                        {
                            // Obtem o código do CID10 inserido e passa como parametro para o método AdicionaCID10
                            formulario.AdicionaCID10(strlstNovaCID10[i].Substring(0, strlstNovaCID10[i].IndexOf('-') - 1));                     
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

                    if (dadosProntuario.mat_Conc02)
                    {
                        formulario.AdicionaMaterial("Conc_02");
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
    }
}
