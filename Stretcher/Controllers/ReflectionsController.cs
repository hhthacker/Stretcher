using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stretcher.Models;

namespace Stretcher.Controllers
{
    [RoutePrefix("api/Reflections")]
    public class ReflectionsController : ApiController
    {
        //POST REFLECTION


        //GET REFLECTION
        //userid and reflectionid
        //[HttpGet, Route("{id}")]
        //public HttpResponseMessage GetOneReflection()
        //{
        //    var db = new ApplicationDbContext();
        //    var reflection = db.Reflections;
        //    return Request.CreateResponse(HttpStatusCode.OK, reflection);
        //}

        //GET ALL REFLECTIONS
        //userid
        [HttpGet, Route("")]
        public HttpResponseMessage GetAllReflections()
        {
            var db = new ApplicationDbContext();
            var reflections = db.Reflections;
            return Request.CreateResponse(HttpStatusCode.OK, reflections);
        }

        //UPDATE REFLECTION

        //DELETE REFLECTION
        //userid and reflectionid
        [HttpDelete, Route("")]
        public HttpResponseMessage DeleteReflection()
        {
            var db = new ApplicationDbContext();
            var deleteReflection = db.Reflections;
            return Request.CreateResponse(HttpStatusCode.OK, deleteReflection);
        }
    }
}
