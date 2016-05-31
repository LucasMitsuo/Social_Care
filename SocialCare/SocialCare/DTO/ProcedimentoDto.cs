using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCare.DTO
{
    public class ProcedimentoDto
    {
        public int id;
        public string descricao;

        public ProcedimentoDto(TAB_PROCEDIMENTO procedimento)
        {
            this.id = procedimento.cod_procedimento;
            this.descricao = procedimento.nom_procedimento + " - " + procedimento.obs_procedimento;
        }
    }
}