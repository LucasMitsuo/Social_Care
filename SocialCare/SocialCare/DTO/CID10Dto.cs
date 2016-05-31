using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCare.DTO
{
    public class CID10Dto
    {
        public int id { get; set; }
        public string descricao { get; set; }


        public CID10Dto(TAB_CID cid10)
        {
            this.id = cid10.cod_cid;
            this.descricao = cid10.cod_cid10 + " - " + cid10.des_cid;
        }
    }
}