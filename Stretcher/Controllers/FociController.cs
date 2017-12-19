using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/foci")]
    public class FociController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetAllFoci()
        {
            var db = new ApplicationDbContext();
            var foci = db.Foci;
            return Request.CreateResponse(HttpStatusCode.OK, foci);
        }

        [HttpGet, Route("{id}")]
        public HttpResponseMessage GetOneFocus(int id)
        {
            var db = new ApplicationDbContext();
            var focus = db.Foci.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, focus);
        }

    }
}
