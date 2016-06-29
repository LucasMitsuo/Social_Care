using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialCare.Models
{
    [MetadataType(typeof(TAB_FORMMetadata))]
    public partial class TAB_FORM
    {
        SocialCareEntities db = new SocialCareEntities();

        /// <summary>
        /// Adiciona um novo material
        /// </summary>
        /// <param name="nomeMaterial">Nome do Material</param>
        public void AdicionaMaterial(string nomeMaterial)
        {
            var material = db.TAB__MATERIAL.Where(model => model.nom_material.Equals(nomeMaterial)).FirstOrDefault();

            var novoMaterial = new TAB_FORM_MAT()
            {
                cod_material = material.cod_material,
                cod_form = this.cod_form
            };

            db.TAB_FORM_MAT.Add(novoMaterial);
            db.SaveChanges();
        }

        /// <summary>
        /// Exclui um material
        /// </summary>
        /// <param name="nomeMaterial">Nome do material</param>
        public void ExcluiMaterial(string nomeMaterial)
        {
            var material = db.TAB__MATERIAL.Where(model => model.nom_material.Equals(nomeMaterial)).FirstOrDefault();

            db.TAB_FORM_MAT.Remove(material.TAB_FORM_MAT.Where(model => model.cod_form == this.cod_form).FirstOrDefault());
            db.SaveChanges();
        }
        
        /// <summary>
        /// Adiciona um CID 10
        /// </summary>
        /// <param name="codCid10">Código do CID10</param>
        public void AdicionaCID10 (String codCid10)
        {
            var cid10 = db.TAB_CID.Where(model => model.cod_cid10 == codCid10).FirstOrDefault();

            var novoDiagnostico = new TAB_DIAGNOSTICO()
            {
                cod_cid = cid10.cod_cid,
                cod_form = this.cod_form
            };

            db.TAB_DIAGNOSTICO.Add(novoDiagnostico);
            db.SaveChanges();


        }

        /// <summary>
        /// Exclui um CID10
        /// </summary>
        /// <param name="codCid10">Código do CID10</param>
        public void ExcluiCID10 (string codCid10)
        {
            var cid10 = db.TAB_CID.Where(model => model.cod_cid10 == codCid10).FirstOrDefault();
            db.TAB_DIAGNOSTICO.Remove(cid10.TAB_DIAGNOSTICO.Where(model => model.cod_form == this.cod_form).FirstOrDefault());
            db.SaveChanges();
            
        }

        /// <summary>
        /// Adiciona um Procedimento Enfermeira
        /// </summary>
        /// <param name="nomeProcEnf">Nome do procedimento Enfermeira</param>
        public void AdicionaObsEnfermeira (string nomeProcEnf)
        {
            var obsEnfermeira = db.TAB_PROC_ENF.Where(model => model.nom_proc_enf.Equals(nomeProcEnf)).FirstOrDefault();
            var novoObsEnfermeira = new TAB_FORM_PROC_ENF()
            {
                cod_proc_enf = obsEnfermeira.cod_proc_enf,
                cod_form = this.cod_form

            };

            db.TAB_FORM_PROC_ENF.Add(novoObsEnfermeira);
            db.SaveChanges();

        }
        
        /// <summary>
        /// Exclui um procedimento enfermeira
        /// </summary>
        /// <param name="nomeProcEnf">Nome do procedimento enfermeira</param>
        public void ExcluiObsEnfermeira (string nomeProcEnf)
        {
            var obsEnfermeira = db.TAB_PROC_ENF.Where(model => model.nom_proc_enf.Equals(nomeProcEnf)).FirstOrDefault();
            db.TAB_FORM_PROC_ENF.Remove(obsEnfermeira.TAB_FORM_PROC_ENF.Where(model => model.cod_form == this.cod_form).FirstOrDefault());
            db.SaveChanges();
        } 


    }

    public class TAB_FORMMetadata
    {
        public int cod_form { get; set; }
        public int cod_paciente { get; set; }
    }
}