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

        public void ExcluiMaterial(string nomeMaterial)
        {
            var material = db.TAB__MATERIAL.Where(model => model.nom_material.Equals(nomeMaterial)).FirstOrDefault();

            db.TAB_FORM_MAT.Remove(material.TAB_FORM_MAT.Where(model => model.cod_form == this.cod_form).FirstOrDefault());
            db.SaveChanges();
        }

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

        public void ExcluiCID10 (string codCid10)
        {
            var cid10 = db.TAB_CID.Where(model => model.cod_cid10 == codCid10).FirstOrDefault();
            db.TAB_DIAGNOSTICO.Remove(cid10.TAB_DIAGNOSTICO.Where(model => model.cod_form == this.cod_form).FirstOrDefault());
            db.SaveChanges();
            
        }


    }

    public class TAB_FORMMetadata
    {
        public int cod_form { get; set; }
        public int cod_paciente { get; set; }
    }
}