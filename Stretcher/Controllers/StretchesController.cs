using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;
using Stretcher.ViewModels;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/Stretches")]
    public class StretchesController : ApiController
    {
        [HttpGet, Route("")]
        public HttpResponseMessage GetAllStretches()
        {
            var db = new ApplicationDbContext();
            var stretches = db.Stretches;
            return Request.CreateResponse(HttpStatusCode.OK, stretches);

        }
        
        [HttpGet, Route("id")]
        public HttpResponseMessage GetOneStretch(Stretch id)
        {
            var db = new ApplicationDbContext();
            var stretch = db.Stretches.Find(id);
            return Request.CreateResponse(HttpStatusCode.OK, stretch);
            
        }
    }
}