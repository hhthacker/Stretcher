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
    [RoutePrefix("api/Reflections")]
    public class ReflectionsController : ApiController
    {
        [HttpPost, Route("")]
        public HttpResponseMessage PostNewReflection(PostNewReflection PostNewReflection)
        {
            var db = new ApplicationDbContext();
            var newReflection = new Reflection
                {
                    ReflectionTitle = PostNewReflection.ReflectionTitle,
                    ReflectionNotes = PostNewReflection.ReflectionNotes
                };

            db.Reflections.Add(newReflection);
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, newReflection);
        }

        [HttpGet, Route("")]
        public HttpResponseMessage GetAllReflections()
        {
            var db = new ApplicationDbContext();
            var reflections = db.Reflections;
            return Request.CreateResponse(HttpStatusCode.OK, reflections);
        }

        [HttpDelete, Route("{id}")]
        public HttpResponseMessage DeleteReflection(int id)
        {
            var db = new ApplicationDbContext();
            var deleteReflection = db.Reflections.Remove(db.Reflections.Find(id));
            db.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
