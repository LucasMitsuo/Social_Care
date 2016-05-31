using SocialCare.DTO;
using SocialCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialCare.Controllers
{
    public class ServicosController : ApiController
    {
        [HttpGet]
        [Route("api/cid10")]
        public HttpResponseMessage ObterCID10()
        {
            SocialCareEntities db = new SocialCareEntities();

            var result = db.TAB_CID.ToList();

            var colCID10 = from c in result select new CID10Dto(c).descricao;

            return Request.CreateResponse(HttpStatusCode.OK, colCID10.ToArray());
        }
    }
}
