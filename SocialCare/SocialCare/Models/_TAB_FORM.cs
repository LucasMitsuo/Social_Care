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

            var _material = new TAB_FORM_MAT()
            {
                cod_material = material.cod_material,
                cod_form = this.cod_form
            };

            db.TAB_FORM_MAT.Remove(_material);
            db.SaveChanges();
        }
    }

    public class TAB_FORMMetadata
    {
        public int cod_form { get; set; }
        public int cod_paciente { get; set; }
    }
}